using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CIRC.Core.MiniGames.Sample.SortAndSplodeMiniGame
{
    public class SortAndSplodeSpawner : MonoBehaviour
    {
        [Header("Spawn Entity Data")]
        [field: SerializeField] public int EntitiesToSpawn { get; private set; } = 10;
        [SerializeField] private float _spawnTimeout = 1;
        [SerializeField] private Entity[] _entityTypes;
        [SerializeField] private RectTransform _spawnArea;
        
        public int SpawnCount { get; private set; }
        public event Action<Entity> OnEntitySpawned;
        
        private IEnumerator Start() //Spawns the Entities
        {
            SpawnCount = 0;
            while (SpawnCount < EntitiesToSpawn)
            {
                Vector2 spawnPosition = _spawnArea.GetRandomPositionWithinRectTransform();
                
                Entity entity = Instantiate(_entityTypes[Random.Range(0, _entityTypes.Length)], spawnPosition, Quaternion.identity, _spawnArea);

                entity.RectTransform.anchoredPosition = spawnPosition;
                entity.MoveArea = _spawnArea;
                entity.FirstFrame();
                
                OnEntitySpawned?.Invoke(entity);

                SpawnCount++;
                yield return new WaitForSeconds(_spawnTimeout);
            }
        }
    }
}