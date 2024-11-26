using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CIRC.Core.MiniGames.Sample.SortAndSplodeMiniGame
{
    public class SortAndSplodeSpawner : MonoBehaviour
    {
        [Header("Spawn Entity Data")]
        [SerializeField] private Entity[] _entityTypes;
        [SerializeField] private RectTransform _spawnArea;
        
        public int Remainings { get; private set; }
        public event Action<Entity> OnEntitySpawned;
        
        private IEnumerator Start() //Spawns the Entities
        {
            Remainings = GameController.Metrics.SortAndSplode_SpawnNumber;
            
            for (int i = GameController.Metrics.SortAndSplode_SpawnNumber; i > 0; i--)
            {
                Vector2 spawnPosition = _spawnArea.GetRandomPositionWithinRectTransform();
                
                Entity entity = Instantiate(_entityTypes[Random.Range(0, _entityTypes.Length)], spawnPosition, Quaternion.identity, _spawnArea);

                entity.RectTransform.anchoredPosition = spawnPosition;
                entity.MoveArea = _spawnArea;
                entity.FirstFrame();
                
                OnEntitySpawned?.Invoke(entity);

                Remainings--;
                yield return new WaitForSeconds(GameController.Metrics.SortAndSplode_SpawnCooldown);
            }
        }
    }
}