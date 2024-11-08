using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NomDuJeu.MiniGames.Core
{
    public class EntityManager : MonoBehaviour
    {
        [SerializeField] private int entityToSpawn = 1;
        [SerializeField] private GameObject[] entities;
        
        private List<Entity> spawnedEntities = new List<Entity>();
        [SerializeField] private BoxCollider2D moveBounds;

        private void Awake()
        {
            /*
            for (int i = 0; i < spawnedEntities.Count; i++)
            {
                spawnedEntities[i].LoadScene();
            }
            */
        }
        
        private void Start()
        {
            StartCoroutine(SpawnEntitiesCoroutine());
        }

        private IEnumerator SpawnEntitiesCoroutine()
        {
            while (spawnedEntities.Count < entityToSpawn)
            {
                Vector3 randomPosition = new Vector3(
                    Random.Range(moveBounds.bounds.min.x, moveBounds.bounds.max.x),
                    Random.Range(moveBounds.bounds.min.y, moveBounds.bounds.max.y),
                    0f
                );
                
                Entity entity = Instantiate(entities[Random.Range(0, entities.Length)], randomPosition, Quaternion.identity).GetComponent<Entity>();
                entity.moveBounds = moveBounds;
                
                entity.FirstFrame();
                spawnedEntities.Add(entity);

                yield return new WaitForSeconds(2f);
            }
        }

        private void Update()
        {
            for (int i = 0; i < spawnedEntities.Count; i++)
            {
                spawnedEntities[i].Refresh();
            }
        }
    }
}
