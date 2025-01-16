using System.Linq;
using SaveSystem.Core;
using UnityEngine;
using CIRC.Progression;

namespace CIRC.Controllers
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