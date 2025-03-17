using System.Collections.Generic;
using System.Linq;
using SaveSystem.Core;

namespace CIRC.Progression
{
    public class ProgressionManager : ISaveListener<GameSave>
    {
        public int Priority => 1;
        public Dictionary<string, (bool, int)> miniGameStatus { get; private set; } = new();
        
        public void Write(ref GameSave saveFile)
        {
            saveFile.miniGameStatus = miniGameStatus
                .Select(ctx => 
                    new MiniGameStatus
                    {
                        ID = ctx.Key, 
                        Status = ctx.Value.Item1,
                        LevelIndex = ctx.Value.Item2
                    })
                .ToArray();
        }

        public void Read(in GameSave saveFile)
        {
            miniGameStatus.Clear();

            for (int i = 0; i < saveFile.miniGameStatus.Length; i++)
            {
                MiniGameStatus miniGame = saveFile.miniGameStatus[i];
                miniGameStatus.Add(miniGame.ID, (miniGame.Status, miniGame.LevelIndex));
            }
        }

        public void CompleteMiniGame(string ID)
        {
            if (miniGameStatus.TryGetValue(ID, out (bool, int) game))
            {
                miniGameStatus[ID] = (true, game.Item2);
            }
        }

        public void ResetMiniGame(string ID)
        {
            if (miniGameStatus.TryGetValue(ID, out (bool, int) game))
            {
                miniGameStatus[ID] = (false, game.Item2);
            }
        }
    }
}