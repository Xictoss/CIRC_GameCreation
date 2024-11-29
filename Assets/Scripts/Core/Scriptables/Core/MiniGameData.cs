using NaughtyAttributes;
using UnityEngine;

namespace CIRC.Core.Scriptables.Core
{
    [CreateAssetMenu(fileName = "NewMiniGameScriptable", menuName = "CIRC/Save/MiniGameScriptable", order = 0)]
    public class MiniGameData : SaveScriptable
    {
        public string gameName;
        public GameSubject subject;
        public BadgeData badge;
        
        [Button]
        public void GenerateGuid()
        {
            saveElement.SetNewGuid();
        }
        [Button]
        public void ResetName()
        {
            gameName = name;
        }
    }
    
    [System.Serializable]
    public enum GameSubject
    {
        Alimentation,
        Hydratation,
        AlcoolSodas,
        
        MedicamentsHormonaux,
        Depistage,
        HPV,
        
        ExpositionSoleil,
        Tabagisme,
        ZoneRadon,
        RisquesChimique,
        Allaitement,
        
        ActivitePhysique,
        Surpoids,
    }
}