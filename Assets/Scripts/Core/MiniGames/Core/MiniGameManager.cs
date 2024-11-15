using System;
using System.Collections.Generic;
using LTX.Singletons;
using LTX.Tools;
using NomDuJeu.MiniGames.Core.Core.MiniGames.Core.Interfaces;

namespace NomDuJeu.MiniGames.Core.Core.MiniGames.Core
{
    public class MiniGameManager : MonoSingleton<MiniGameManager>
    {
        public event Action<IMiniGameRunner> OnMiniGameStarted;
        public event Action<IMiniGameRunner> OnMiniGameStopped;

        private List<IMiniGameRunner> miniGameRunners;
        private DynamicBuffer<IMiniGameRunner> miniGameRunnersBuffer;

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
            
            OnMiniGameStarted?.Invoke(runner);
        }
        
        public void StopMiniGame(IMiniGame miniGame, bool isSuccess)
        {
            if (TryGetMiniGameRunner(miniGame, out IMiniGameRunner runner))
            {
                runner.End(isSuccess);
                miniGameRunners.Remove(runner);
            
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