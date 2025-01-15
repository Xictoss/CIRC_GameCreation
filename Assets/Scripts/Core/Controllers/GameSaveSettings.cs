using System.Linq;
using CIRC.Core.Progression.Core;
using SaveSystem.Core;
using UnityEngine;

namespace CIRC.Core.Controllers
{
    public struct GameSaveSettings : ISaveFileSettings<GameSave>
    {
        public string prefName;
        public GameSave GetDefaultSaveFile()
        {
            return new GameSave()
            {
                miniGameStatus = Resources.LoadAll<MiniGameDataHolder>("Games")
                    .Select(ctx => new MiniGameStatus()
                    {
                        ID = ctx.GUID,
                        Status = false
                    })
                    .ToArray()
            };
        }
    }
}