using System;
using System.Collections.Generic;
using CIRC.Core.MiniGames.Core.Interfaces;
using LTX.Singletons;
using LTX.Tools;
using UnityEngine;

namespace CIRC.Core.MiniGames.Core
{
    public class MiniGameManager : MonoSingleton<MiniGameManager>
    {
        public event Action<IMiniGameRunner> OnMiniGameStarted;
        public event Action<IMiniGameRunner> OnMiniGameStopped;

        private List<IMiniGameRunner> miniGameRunners;
        private DynamicBuffer<IMiniGameRunner> miniGameRunnersBuffer;
        
        public IMiniGameRunner currentMiniGame { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            miniGameRunners = new List<IMiniGameRunner>();
            miniGameRunnersBuffer = new DynamicBuffer<IMiniGameRunner>(64);
        }

        private void Update()
        {
            miniGameRunnersBuffer.CopyFrom(miniGameRunners);
            for (int i = 0; i < miniGameRunnersBuffer.Length; i++)
            {
                if (miniGameRunnersBuffer[i].Refresh())
                {
                    StopMiniGame(miniGameRunnersBuffer[i].MiniGame, true);
                }
            }
        }

        public void StartMiniGame<T>(MiniGame<T> miniGame, IMiniGameHandler<T> miniGameHandler)
            where T : IMiniGameContext
        {
            if (TryGetMiniGameRunner(miniGame, out IMiniGameRunner runner)) return;

            MiniGameRunner<T> miniGameRunner = new MiniGameRunner<T>(miniGame, miniGameHandler);
            
            miniGameRunners.Add(miniGameRunner);
            miniGameRunner.Begin();

            currentMiniGame = miniGameRunner;
            OnMiniGameStarted?.Invoke(miniGameRunner);
        }
        
        public void StopMiniGame(IMiniGame miniGame, bool isSuccess)
        {
            if (TryGetMiniGameRunner(miniGame, out IMiniGameRunner runner))
            {
                runner.End(isSuccess);
                miniGameRunners.Remove(runner);

                currentMiniGame = null;
                OnMiniGameStopped?.Invoke(runner);
            }
        }

        private bool TryGetMiniGameRunner(IMiniGame miniGame, out IMiniGameRunner miniGameRunner)
        {
            foreach (IMiniGameRunner runner in miniGameRunners)
            {
                if (runner.MiniGame == miniGame)
                {
                    miniGameRunner = runner;
                    return true;
                }
            }

            miniGameRunner = null;
            return false;
        }
    }
}