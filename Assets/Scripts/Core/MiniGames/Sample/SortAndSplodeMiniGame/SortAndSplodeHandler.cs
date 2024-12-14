using CIRC.Core.Controllers;
using CIRC.Core.MiniGames.Core;
using CIRC.Core.MiniGames.Core.Interfaces;
using CIRC.Core.Progression.Core.Data;
using LTX.ChanneledProperties;
using UnityEngine;
using UnityEngine.Serialization;

namespace CIRC.Core.MiniGames.Sample.SortAndSplodeMiniGame
{
    public class SortAndSplodeHandler : MonoBehaviour, IMiniGameHandler<SortAndSplodeContext>
    {
        [FormerlySerializedAs("miniGameData")] [SerializeField] private MiniGameDataOLD miniGameDataOld;
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
                MiniGameDataOld = miniGameDataOld,
                Spawner = spawner,
                EntityManager = entityManager,
            };
        }
    }
}