using CIRC.Core.Controllers;
using CIRC.Core.MiniGames.Core;
using UnityEngine;

namespace CIRC.Core.MiniGames.Sample.TabagismeMaisonSecouer
{
    public class TabagismeMaisonSecouer : MiniGame<TabagismeMaisonSecouerContext>
    {
        public override void Begin(ref TabagismeMaisonSecouerContext context)
        {
        }

        public override bool Refresh(ref TabagismeMaisonSecouerContext context)
        {
            for (int i = 0; i < context.smokes.Length; i++)
            {
                if (!context.smokes[i].isCleaned)
                {
                    return false;
                }
            }

            return true;
        }

        public override void End(ref TabagismeMaisonSecouerContext context, bool isSuccess)
        {
            Debug.Log("End Mini Game");
            
            if (isSuccess)
            {
                context.MiniGameDataOld.SaveElement.IsComplete = true;
                GameController.SaveData.SetPlayerCompleted(context.MiniGameDataOld.SaveElement);
                GameController.SavePlayerProgressToPlayerPrefsOLD();
            }

            GameController.SceneController.LoadScene(GameController.Metrics.PlageScene);
        }
    }
}