using CIRC.Controllers;
using CIRC.MiniGames.Core;
using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;
using LTX.ChanneledProperties;
using UnityEngine;

namespace CIRC.MiniGames.Sample
{
    public class SortAndSplodeHandler : MonoBehaviour, IMiniGameHandler<SortAndSplodeContext>
    {
        [SerializeField] private MiniGameDataHolder miniGameData;
        [SerializeField] private SortAndSplodeSpawner spawner;
        [field : SerializeField] public EntityManager entityManager { get; private set; }

        private SortAndSplode miniGame;

        private void OnEnable()
        {
            spawner.OnEntitySpawned += entityManager.AddEntity;
            GameController.TimeScale.AddPriority(this, PriorityTags.High, 1f);
        }

        private void OnDisable()
        {
            spawner.OnEntitySpawned -= entityManager.AddEntity;
            GameController.TimeScale.RemovePriority(this);
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
                MiniGameData = miniGameData,
                Spawner = spawner,
                EntityManager = entityManager,
            };
        }
    }
}