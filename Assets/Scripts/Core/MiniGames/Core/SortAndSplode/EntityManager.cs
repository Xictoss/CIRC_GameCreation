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
        [SerializeField] private int entitiesToSpawn = 10;
        [SerializeField] private float spawnTimeout = 1;
        [SerializeField] private GameObject[] entityTypes;
        [SerializeField] private BoxCollider2D spawnBounds;
        
        private readonly List<Entity> spawnedEntities = new List<Entity>();
        private readonly DynamicBuffer<Entity> spawnedEntitiesBuffer = new DynamicBuffer<Entity>(64);
        
        private GameObject draggedEntityGameObject;
        private Entity draggedEntity;

        #region Events

        private void OnEnable()
        {
            SortAndSplodeInputController.Instance.EntityDragged += OnEntityDragged;
            SortAndSplodeInputController.Instance.EntityReleased += OnEntityReleased;
        }
        private void OnDisable()
        {
            SortAndSplodeInputController.Instance.EntityDragged -= OnEntityDragged;
            SortAndSplodeInputController.Instance.EntityReleased -= OnEntityReleased;
        }

        #endregion
        
        private IEnumerator Start() //Spawns the Entities
        {
            int spawnCount = 0;
            while (spawnCount < entitiesToSpawn)
            {
                Vector3 spawnPosition = StaticFunctions.GetRandomPositionWithinBounds2D(spawnBounds, 0f);
                
                GameObject entity = Instantiate(entityTypes[Random.Range(0, entityTypes.Length)], spawnPosition, Quaternion.identity);
                Entity entityScript = entity.GetComponent<Entity>();
                
                entityScript.moveBounds = spawnBounds;
                entityScript.FirstFrame();
                
                spawnedEntities.Add(entityScript);
                spawnedEntitiesBuffer.CopyFrom(spawnedEntities);

                spawnCount++;
                yield return new WaitForSeconds(spawnTimeout);
            }
        }

        private void Update() //Call the entity Update Function
        {
            for (int i = 0; i < spawnedEntitiesBuffer.Length; i++)
            {
                spawnedEntitiesBuffer[i].Refresh();
            }
        }

        private void OnEntityDragged(Collider2D hitObject)
        {
            draggedEntityGameObject = hitObject.gameObject;
            draggedEntity = draggedEntityGameObject.GetComponent<Entity>();

            SetEntityDraggedState(true);
        }
        
        private void OnEntityReleased(Collider2D endZoneCollider)
        {
            SetEntityDraggedState(false);
            
            if (IsValidEndZone(endZoneCollider))
            {
                RemoveEntity();
            }

            draggedEntityGameObject = null;
            draggedEntity = null;
        }
        
        private void SetEntityDraggedState(bool state)
        {
            draggedEntity.isDragged = state;
            draggedEntityGameObject.layer = state ? LayerMask.NameToLayer("Ignore Raycast") : LayerMask.NameToLayer("Default");
        }

        private bool IsValidEndZone(Collider2D endZone)
        {
            if (!endZone) return false;
            
            return (endZone.gameObject.CompareTag("MiniGameZone1") && draggedEntity.entityData.good) || 
                   (endZone.gameObject.CompareTag("MiniGameZone2") && !draggedEntity.entityData.good);
        }
        
        private void RemoveEntity()
        {
            spawnedEntities.Remove(draggedEntity);
            spawnedEntitiesBuffer.CopyFrom(spawnedEntities);

            CheckForGameEnd();
            Destroy(draggedEntityGameObject);
        }
        
        private void CheckForGameEnd()
        {
            if (spawnedEntities.Count == 0)
            {
                MiniGameController.Instance.FinishMiniGame();
            }
        }
    }
}
