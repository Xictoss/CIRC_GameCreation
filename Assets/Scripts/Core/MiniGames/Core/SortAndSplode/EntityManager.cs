using System.Collections;
using System.Collections.Generic;
using CIRC.Core.Inputs.SortAndSplode;
using LTX.Tools;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CIRC.Core.MiniGames.Core.SortAndSplode
{
    public class EntityManager : MonoBehaviour
    {
        [Header("Spawn Entity Data")]
        [SerializeField] private int _entitiesToSpawn = 10;
        [SerializeField] private float _spawnTimeout = 1;
        [SerializeField] private Entity[] _entityTypes;
        [SerializeField] private RectTransform _spawnArea;
        
        private readonly List<Entity> _spawnedEntities = new List<Entity>();
        private readonly DynamicBuffer<Entity> _spawnedEntitiesBuffer = new DynamicBuffer<Entity>(64);
        
        private GameObject _draggedEntityGameObject;
        private Entity _draggedEntity;

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
            while (spawnCount < _entitiesToSpawn)
            {
                Vector2 spawnPosition = _spawnArea.GetRandomPositionWithinRectTransform();
                
                Entity entity = Instantiate(_entityTypes[Random.Range(0, _entityTypes.Length)], spawnPosition, Quaternion.identity, _spawnArea);

                entity.RectTransform.anchoredPosition = spawnPosition;
                entity.MoveArea = _spawnArea;
                entity.FirstFrame();
                
                _spawnedEntities.Add(entity);
                _spawnedEntitiesBuffer.CopyFrom(_spawnedEntities);

                spawnCount++;
                yield return new WaitForSeconds(_spawnTimeout);
            }
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
                RemoveEntity();
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
        
        private void RemoveEntity()
        {
            _spawnedEntities.Remove(_draggedEntity);
            _spawnedEntitiesBuffer.CopyFrom(_spawnedEntities);

            CheckForGameEnd();
            Destroy(_draggedEntityGameObject);
        }
        
        private void CheckForGameEnd()
        {
            if (_spawnedEntities.Count == 0)
            {
                MiniGameController.Instance.FinishMiniGame();
            }
        }
    }
}
