using NomDuJeu.Progression.Core;
using UnityEditor;
using UnityEngine;

namespace NomDuJeu.Scriptables.Core
{
    [CreateAssetMenu(fileName = "NewSaveScriptable", menuName = "SaveScriptable", order = 1)]
    public class SaveScriptable : ScriptableObject
    {
        public SaveElement scriptableSaveElement;
        public string saveElementName;
    }
}