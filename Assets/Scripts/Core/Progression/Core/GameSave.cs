using SaveSystem.Core;

namespace CIRC.Core.Progression.Core
{
    [System.Serializable]
    public struct GameSave : ISaveFile
    {
        public int Version => 1;
        public MiniGameStatus[] miniGameStatus;
    }
}