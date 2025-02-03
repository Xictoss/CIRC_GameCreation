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

            // Check if the GUID is empty or invalid
            if (string.IsNullOrEmpty(miniGameDataHolder.GUID))
            {
                GenerateNewGuid(miniGameDataHolder);
            }
        }

        private void GenerateNewGuid(MiniGameDataHolder miniGameDataHolder)
        {
            SerializedObject serializedObject = new SerializedObject(miniGameDataHolder);
            SerializedProperty guidProperty = serializedObject.FindProperty("GUID");

            // Generate a new GUID
            guidProperty.stringValue = System.Guid.NewGuid().ToString();

            // Apply changes and save the asset
            serializedObject.ApplyModifiedProperties();
            EditorUtility.SetDirty(miniGameDataHolder);
            AssetDatabase.SaveAssets();

            Debug.Log($"Generated new GUID: {guidProperty.stringValue} for {miniGameDataHolder.miniGameName}");
        }
    }
}