using System.Collections;
using System.Collections.Generic;
using LTX.Tools;
using NomDuJeu.Core;
using NomDuJeu.Inputs.SortAndSplode;
using UnityEngine;
using Random = UnityEngine.Random;

namespace NomDuJeu.MiniGames.Core.SortAndSplode
{
    public class EntityManager : MonoBehaviour
    {
        [SerializeField] private int entityToSpawn = 1;
        [SerializeField] private int spawnTimeout = 1;
        [SerializeField] private GameObject[] entities;
        
        private List<Entity> spawnedEntities;
        private DynamicBuffer<Entity> spawnedEntitiesBuffer;
        private GameObject draggedGameObject;
        private Entity draggedEntity;
        
        [SerializeField] private BoxCollider2D boundsCollider;

        private void OnEnable()
        {
            SortAndSplodeInput.Instance.EntityDragged += OnEntityDragged;
            SortAndSplodeInput.Instance.EntityReleased += OnEntityReleased;
            SortAndSplodeInput.Instance.EntityReleasedOnEmpty += OnEntityReleasedOnEmpty;
        }
        private void OnDisable()
        {
            SortAndSplodeInput.Instance.EntityDragged -= OnEntityDragged;
            SortAndSplodeInput.Instance.EntityReleased -= OnEntityReleased;
            SortAndSplodeInput.Instance.EntityReleasedOnEmpty -= OnEntityReleasedOnEmpty;
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
                //Implement logic for MiniGame isComplete + Badge
            }
        }

        private void OnEntityDragged(GameObject hitObject)
        {
            draggedGameObject = hitObject;
            draggedEntity = draggedGameObject.GetComponent<Entity>();

            SetEntityDragged(true);
        }
        
        private void OnEntityReleased(GameObject releasedInZone)
        {
            if (!draggedGameObject) return;

            SetEntityDragged(false);
            
            if (ValidEndZone(releasedInZone)) //Correct End Zone
            {
                //Debug.Log("Correct Object Drag");
                spawnedEntities.Remove(draggedEntity);
                Destroy(draggedGameObject);
            }
            else //Incorrect End Zone
            {
                //Debug.Log("Not a Correct Object Drag !!!");
                draggedGameObject.layer = LayerMask.NameToLayer("Default");
            }

            SetEntityReferencesNull();
        }

        private void OnEntityReleasedOnEmpty()
        {
            SetEntityDragged(false);
            SetEntityReferencesNull();
        }

        private bool ValidEndZone(GameObject zone)
        {
            EntityData entityData = draggedGameObject.GetComponent<Entity>().entityData;
            
            return (zone.CompareTag("MiniGameZone1") && entityData.Good) || (zone.CompareTag("MiniGameZone2") && !entityData.Good);
        }

        private void SetEntityReferencesNull()
        {
            draggedGameObject = null;
            draggedEntity = null;
        }

        private void SetEntityDragged(bool state)
        {
            draggedEntity.isDragged = state;
            draggedGameObject.layer = state ? LayerMask.NameToLayer("Ignore Raycast") : LayerMask.NameToLayer("Default");
        }
    }
}
