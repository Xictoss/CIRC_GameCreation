using System.Collections;
using System.Collections.Generic;
using System.Linq;
using LTX.Tools;
using NomDuJeu.Core;
using UnityEngine;
using Random = UnityEngine.Random;

namespace NomDuJeu.MiniGames.Core
{
    public class EntityManager : MonoBehaviour
    {
        [SerializeField] private int entityToSpawn = 1;
        [SerializeField] private int spawnTimeout = 1;
        [SerializeField] private GameObject[] entities;
        
        private List<Entity> spawnedEntities;
        private DynamicBuffer<Entity> spawnedEntitiesBuffer;
        private GameObject draggedGameObject;
        
        [SerializeField] private BoxCollider2D boundsCollider;

        private void OnEnable()
        {
            InputController.Instance.EntityDragged += OnEntityDragged;
            InputController.Instance.EntityReleased += OnEntityReleased;
            InputController.Instance.EntityReleasedOnEmpty += OnEntityReleasedOnEmpty;
        }
        private void OnDisable()
        {
            InputController.Instance.EntityDragged -= OnEntityDragged;
            InputController.Instance.EntityReleased -= OnEntityReleased;
            InputController.Instance.EntityReleasedOnEmpty -= OnEntityReleasedOnEmpty;
        }

        private void Awake()
        {
            spawnedEntities = new List<Entity>();
            spawnedEntitiesBuffer = new DynamicBuffer<Entity>(64);
        }
        
        private IEnumerator Start()
        {
            while (spawnedEntities.Count < entityToSpawn)
            {
                Vector3 randomPosition = StaticFunctions.GetRandomPositionWithinBounds2D(boundsCollider, 0f);
                
                GameObject entity = Instantiate(entities[Random.Range(0, entities.Length)], randomPosition, Quaternion.identity);
                Entity entityScript = entity.GetComponent<Entity>();
                
                entityScript.boundsCollider = boundsCollider;
                entityScript.FirstFrame();
                
                spawnedEntities.Add(entityScript);

                yield return new WaitForSeconds(spawnTimeout);
            }
        }

        private void Update()
        {
            spawnedEntitiesBuffer.CopyFrom(spawnedEntities);
                
            for (int i = 0; i < spawnedEntitiesBuffer.Length; i++)
            {
                spawnedEntitiesBuffer[i].Refresh();
            }

            if (spawnedEntities.Count == 0)
            {
                Debug.Log("Player Won !!!");
            }
        }

        private void OnEntityDragged(GameObject hitObject)
        {
            draggedGameObject = hitObject;
            draggedGameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
            draggedGameObject.GetComponent<Entity>().isDragged = true;
        }
        
        private void OnEntityReleased(GameObject releasedInZone)
        {
            if (!draggedGameObject) return;
            
            draggedGameObject.GetComponent<Entity>().isDragged = false;
            
            if (ValidEndZone(releasedInZone))
            {
                //Debug.Log("Correct Object Drag");
                
                spawnedEntities.Remove(draggedGameObject.GetComponent<Entity>());
                Destroy(draggedGameObject, 0.5f);
                draggedGameObject = null;
            }
            else
            {
                //Debug.Log("Not a Correct Object Drag !!!");
                
                draggedGameObject.layer = LayerMask.NameToLayer("Default");
                draggedGameObject = null;
            }
        }

        private void OnEntityReleasedOnEmpty()
        {
            draggedGameObject.layer = LayerMask.NameToLayer("Default");
            draggedGameObject.GetComponent<Entity>().isDragged = false;
            draggedGameObject = null;
        }

        private bool ValidEndZone(GameObject zone)
        {
            EntityData entityData = draggedGameObject.GetComponent<Entity>().entityData;
            
            return (zone.CompareTag("MiniGameZone1") && entityData.Good) || (zone.CompareTag("MiniGameZone2") && !entityData.Good);
        }
    }
}
