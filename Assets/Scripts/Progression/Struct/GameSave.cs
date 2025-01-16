using SaveSystem.Core;

namespace CIRC.Progression
{
    [System.Serializable]
    public struct GameSave : ISaveFile
    {
        public int Version => 1;
        public MiniGameStatus[] miniGameStatus;
    }
}