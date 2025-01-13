using System;
using CIRC.Core.Progression.Core.Core.Progression.Core;

namespace CIRC.Core.Progression.Core
{
    [Serializable]
    public struct MiniGameData
    {
        public string MiniGameId;
        public bool IsCompleted;

        public GameSubject GameSubject;
        public BadgeData BadgeDisplay;

        public MiniGameData(string id, bool isCompleted, BadgeData badge, GameSubject subject)
        {
            MiniGameId = id;
            IsCompleted = isCompleted;
            BadgeDisplay = badge;
            GameSubject = subject;
        }
    }
}