using LTX.Singletons;
using NomDuJeu.Scriptables.Core;
using UnityEngine;
using NomDuJeu.Core;

namespace NomDuJeu.MiniGames.Core
{
    public class MiniGameController : MonoSingleton<MiniGameController>
    {
        [field : SerializeField] public MiniGameScriptable MiniGameScriptable { get; private set; }

        public void FinishMiniGame()
        {
            SaveProgress();
            StaticFunctions.LoadScene(0);
        }

        private void SaveProgress()
        {
            MiniGameScriptable.ScriptableSaveElement.IsComplete = true;
            MiniGameScriptable.MiniGameBadge.ScriptableSaveElement.IsComplete = true;
            
            GameController.SavePlayerProgressToPlayerPrefs();
        }
    }
}
