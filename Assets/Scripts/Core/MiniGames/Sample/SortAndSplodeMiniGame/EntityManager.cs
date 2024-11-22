using System.Collections.Generic;
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
        
        public void AddEntity(Entity entity)
        {
            entity.manager = this;
            
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
    }
}