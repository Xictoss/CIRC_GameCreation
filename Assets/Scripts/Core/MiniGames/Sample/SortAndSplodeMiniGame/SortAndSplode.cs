using NomDuJeu.Core.MiniGames.Sample.SortAndSplode;
using NomDuJeu.MiniGames.Core;

namespace NomDuJeu.Core.MiniGames.Sample.SortAndSplode
{
    public class SortAndSplode : MiniGame<SortAndSplodeContext>
    {

        public SortAndSplode()
        {
            
        }
        
        public override void Begin(ref SortAndSplodeContext context)
        {
        }

        public override bool Refresh(ref SortAndSplodeContext context)
        {
            return true;
        }

        public override void End(ref SortAndSplodeContext context, bool isSuccess)
        {
        }
    }
}