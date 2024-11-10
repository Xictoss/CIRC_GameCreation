using LTX.Singletons;
using NomDuJeu.Scriptables.Core;
using UnityEngine;
using NomDuJeu.Core;

namespace NomDuJeu.MiniGames.Core
{
    public class MiniGameController : MonoSingleton<MiniGameController>
    {
        [field : SerializeField] public MiniGameScriptable _miniGameScriptable { get; private set; }

        public void FinishMiniGame()
        {
            _miniGameScriptable.ScriptableSaveElement.IsComplete = true;
            _miniGameScriptable.MiniGameBadge.ScriptableSaveElement.IsComplete = true;
            StaticFunctions.LoadScene(0);
        }
    }
}
