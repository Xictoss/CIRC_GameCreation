using CIRC.Controllers;
using CIRC.MiniGames.Core;
using UnityEngine;

namespace CIRC.MiniGames.Sample
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
                GameController.ProgressionManager.CompleteMiniGame(context.MiniGameData.GUID);
                GameController.SaveProgress();
            }

            GameController.SceneController.LoadScene(GameController.Metrics.PlageScene);
        }
    }
}