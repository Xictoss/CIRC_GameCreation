using System.Collections.Generic;
using System.Linq;
using SaveSystem.Core;

namespace CIRC.Progression
{
    public class ProgressionManager : ISaveListener<GameSave>
    {
        public int Priority => 1;
        public Dictionary<string, bool> miniGameStatus { get; private set; } = new Dictionary<string, bool>();
        
        public void Write(ref GameSave saveFile)
        {
            saveFile.miniGameStatus = miniGameStatus
                .Select(ctx => 
                    new MiniGameStatus
                    {
                        ID = ctx.Key, 
                        Status = ctx.Value
                    })
                .ToArray();
        }

        public void Read(in GameSave saveFile)
        {
            miniGameStatus.Clear();

            for (int i = 0; i < saveFile.miniGameStatus.Length; i++)
            {
                MiniGameStatus miniGame = saveFile.miniGameStatus[i];
                miniGameStatus.Add(miniGame.ID, miniGame.Status);
            }
        }

        public void CompleteMiniGame(string ID)
        {
            if (!miniGameStatus.TryAdd(ID, true))
            {
                miniGameStatus[ID] = true;
            }
        }

        public void ResetMiniGame(string ID)
        {
            if (!miniGameStatus.TryAdd(ID, false))
            {
                miniGameStatus[ID] = false;
            }
        }
    }
}