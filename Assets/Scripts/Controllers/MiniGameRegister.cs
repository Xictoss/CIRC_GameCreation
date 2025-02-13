using CIRC.Progression;

namespace CIRC.Controllers
{
    public class MiniGameRegister
    {
        public static MiniGameRegister Global => GameController.MiniGameRegister;

        public MiniGameDataHolder currentMiniGame { get; private set; }

        public void SetCurrentMiniGame(MiniGameDataHolder data)
        {
            currentMiniGame = data;
        }
    }
}