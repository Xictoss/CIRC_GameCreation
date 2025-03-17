using System.IO;
using CIRC.Progression;
using UnityEditor;
using UnityEngine;

namespace CIRC.Editor
{
    [CustomEditor(typeof(MiniGameDataHolder))]
    public class MiniGameDataHolderEditor : UnityEditor.Editor
    {
        private void OnEnable()
        {
            var miniGameDataHolder = target as MiniGameDataHolder;
            SerializedObject serializedObject = new SerializedObject(miniGameDataHolder);

            // Check if the GUID is empty or invalid
            if (string.IsNullOrEmpty(miniGameDataHolder.GUID))
            {
                SerializedProperty guidProperty = serializedObject.FindProperty("GUID");

                // Generate a new GUID
                guidProperty.stringValue = System.Guid.NewGuid().ToString();
                Debug.Log($"Generated new GUID: {guidProperty.stringValue} for {miniGameDataHolder.miniGameName}");
            }

            var value = AssetDatabase.GetAssetPath(target);
            var dir = Directory.GetParent(value);
            var levelIndex = int.Parse(dir.Name.Split('_')[0]);
            serializedObject.FindProperty("levelInt").intValue = levelIndex;
            
            serializedObject.ApplyModifiedProperties();
            EditorUtility.SetDirty(miniGameDataHolder);
            AssetDatabase.SaveAssets();
        }
    }
}