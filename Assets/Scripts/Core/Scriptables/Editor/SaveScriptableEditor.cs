using NomDuJeu.Scriptables.Core;
using UnityEditor;
using UnityEngine;

namespace NomDuJeu.Scriptables.Editor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(SaveScriptable))]
    public class SaveScriptableEditor : UnityEditor.Editor
    {
        private SaveScriptable saveScriptable;

        #region SerializedProperties

        private SerializedProperty m_ElementName;
        private SerializedProperty m_GuidID;
        private SerializedProperty m_IsComplete;

        #endregion

        private void OnEnable()
        {
            saveScriptable = target as SaveScriptable;

            m_ElementName = serializedObject.FindProperty("saveElementName");
            m_GuidID = serializedObject.FindProperty("scriptableSaveElement.guidID");
            m_IsComplete = serializedObject.FindProperty("scriptableSaveElement.isComplete");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUI.BeginChangeCheck();
            
            EditorGUILayout.LabelField("Scriptable Basic Attributes", EditorStyles.boldLabel);
            m_ElementName.stringValue = EditorGUILayout.TextField("Save Element Name", saveScriptable.saveElementName);
            if (GUILayout.Button("Reset Element Name"))
            {
                m_ElementName.stringValue = saveScriptable.name;
            }
            EditorGUILayout.Space();
            
            EditorGUILayout.LabelField("Save Element", EditorStyles.boldLabel);
            
            m_GuidID.stringValue = EditorGUILayout.TextField("GuidID", saveScriptable.scriptableSaveElement.guidID);
            if (m_GuidID.stringValue == string.Empty)
            {
                if (GUILayout.Button("Generate GUID"))
                {
                    m_GuidID.stringValue = GUID.Generate().ToString();
                }
                EditorGUILayout.Space();
            }
            
            m_IsComplete.boolValue = EditorGUILayout.Toggle("IsComplete", saveScriptable.scriptableSaveElement.isComplete);
            
            EditorGUI.EndChangeCheck();
            serializedObject.ApplyModifiedProperties();
        }
    }
}