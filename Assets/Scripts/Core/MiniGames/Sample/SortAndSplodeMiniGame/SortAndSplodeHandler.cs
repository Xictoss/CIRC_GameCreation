using CIRC.Core.MiniGames.Core;
using CIRC.Core.MiniGames.Core.Interfaces;
using CIRC.Core.Scriptables.Core;
using UnityEngine;

namespace CIRC.Core.MiniGames.Sample.SortAndSplodeMiniGame
{
    public class SortAndSplodeHandler : MonoBehaviour, IMiniGameHandler<SortAndSplodeContext>
    {
        [SerializeField] private MiniGameData miniGameName;
        [SerializeField] private SortAndSplodeSpawner spawner;
        [field : SerializeField] public EntityManager entityManager { get; private set; }

        private SortAndSplode miniGame;

        private void OnEnable()
        {
            spawner.OnEntitySpawned += entityManager.AddEntity;
        }

        private void OnDisable()
        {
            spawner.OnEntitySpawned -= entityManager.AddEntity;
        }

        private void Start()
        {
            miniGame = new SortAndSplode();
            MiniGameManager.Instance.StartMiniGame(miniGame, this);
        }
        
        public SortAndSplodeContext GetContext()
        {
            return new SortAndSplodeContext
            {
                MiniGameData = miniGameName,
                Spawner = spawner,
                EntityManager = entityManager,
            };
        }
    }
}