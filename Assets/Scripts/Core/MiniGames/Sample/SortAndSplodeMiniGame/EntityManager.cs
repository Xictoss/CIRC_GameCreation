using System.Collections.Generic;
using CIRC.Core.Inputs.SortAndSplode;
using LTX.Tools;
using UnityEngine;

namespace CIRC.Core.MiniGames.Sample.SortAndSplodeMiniGame
{
    public class EntityManager : MonoBehaviour
    {
        public List<Entity> SpawnedEntities {get ; private set; } = new List<Entity>();
        private readonly DynamicBuffer<Entity> _spawnedEntitiesBuffer = new DynamicBuffer<Entity>(64);
        
        private GameObject _draggedEntityGameObject;
        private Entity _draggedEntity;

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
        
        public void AddEntity(Entity entity)
        {
            SpawnedEntities.Add(entity);
            _spawnedEntitiesBuffer.CopyFrom(SpawnedEntities);
        }
        
        public void RemoveEntity(Entity entity)
        {
            SpawnedEntities.Remove(entity);
            _spawnedEntitiesBuffer.CopyFrom(SpawnedEntities);
            
            Destroy(_draggedEntityGameObject);
        }
        
        private void Update()
        {
            for (int i = 0; i < _spawnedEntitiesBuffer.Length; i++)
            {
                _spawnedEntitiesBuffer[i].Refresh();
            }
        }
        
        private bool IsUIRaycastHitEntity(GameObject hit) => !IsUIRaycastHitNull(hit) && hit.CompareTag("MiniGameEntity");
        private void OnEntityDragged(GameObject hitObject)
        {
            if (!IsUIRaycastHitEntity(hitObject)) return;
            
            _draggedEntityGameObject = hitObject.gameObject;
            _draggedEntity = _draggedEntityGameObject.GetComponent<Entity>();

            SetEntityDraggedState(true);
        }
        
        private bool IsUIRaycastHitNull(GameObject hit) => hit is null;
        private void OnEntityReleased(GameObject endZoneCollider)
        {
            if (IsUIRaycastHitNull(_draggedEntityGameObject)) return;
            
            SetEntityDraggedState(false);
            
            if (IsValidEndZone(endZoneCollider))
            {
                RemoveEntity(_draggedEntity);
            }

            _draggedEntityGameObject = null;
            _draggedEntity = null;
        }
        
        private void SetEntityDraggedState(bool state)
        {
            _draggedEntity.IsDragged = state;
            _draggedEntityGameObject.layer = state ? LayerMask.NameToLayer("Ignore Raycast") : LayerMask.NameToLayer("UI");
        }

        private bool IsValidEndZone(GameObject endZone)
        {
            if (IsUIRaycastHitNull(endZone)) return false;
            
            return (endZone.CompareTag("MiniGameZone1") && _draggedEntity.EntityData.Good) || 
                   (endZone.CompareTag("MiniGameZone2") && !_draggedEntity.EntityData.Good);
        }
    }
}