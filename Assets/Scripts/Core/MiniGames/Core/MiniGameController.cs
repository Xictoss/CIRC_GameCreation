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
            MiniGameScriptable.scriptableSaveElement.isComplete = true;
            MiniGameScriptable.miniGameBadge.scriptableSaveElement.isComplete = true;
            StaticFunctions.LoadScene(0);
        }
    }
}
