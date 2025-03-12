using LTX.Singletons;
using UnityEngine;

namespace CIRC.MiniGames.Sample
{
    public class MoleculeManager : MonoSingleton<MoleculeManager>
    {
        public bool IsFinished { get; private set; }
        public int _remainingMolecules { get; private set; } = 4;

        public void ChangeRemainingMolecules()
        {
            _remainingMolecules--;
            
            if (_remainingMolecules <= 0)
            {
                IsFinished = true;
            }
        }
    }
}