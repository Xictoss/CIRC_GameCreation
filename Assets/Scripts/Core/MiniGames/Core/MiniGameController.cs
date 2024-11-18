using CIRC.Core.Scriptables.Core;
using LTX.Singletons;
using UnityEngine;

namespace CIRC.Core.MiniGames.Core
{
    public class MiniGameController : MonoSingleton<MiniGameController>
    {
        [field : SerializeField] public MiniGameScriptable MiniGameScriptable { get; private set; }

        public void FinishMiniGame()
        {
            SaveProgress();
            1.LoadScene();
        }

        private void SaveProgress()
        {
            MiniGameScriptable.ScriptableSaveElement.IsComplete = true;
            MiniGameScriptable.MiniGameBadge.ScriptableSaveElement.IsComplete = true;
            
            GameController.SavePlayerProgressToPlayerPrefs();
        }
    }
}
