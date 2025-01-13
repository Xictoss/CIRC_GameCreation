using UnityEditor;
using UnityEngine;

namespace CIRC.Core.Progression.Core.Core.Progression.Core
{
    [CustomEditor(typeof(SaveManager))]
    public class SaveManagerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            SaveManager saveManager = (SaveManager)target;

            DrawDefaultInspector();

            if (GUILayout.Button("Print All Data"))
            {
                saveManager.PrintAllData();
            }

            if (GUILayout.Button("Save Data"))
            {
                saveManager.SaveData();
            }

            if (GUILayout.Button("Load Data"))
            {
                saveManager.LoadData();
            }
        }
    }
}