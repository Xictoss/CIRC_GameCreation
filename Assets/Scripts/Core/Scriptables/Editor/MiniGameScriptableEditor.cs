using NomDuJeu.Scriptables.Core;
using UnityEditor;
using UnityEngine;

namespace NomDuJeu.Scriptables.Editor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(MiniGameScriptable))]
    public class MiniGameScriptableEditor : UnityEditor.Editor
    {
        private SaveScriptable saveScriptable;

        #region SerializedProperties

        private SerializedProperty m_MiniGameName;
        private SerializedProperty m_MiniGameBadge;
        
        private SerializedProperty m_GuidID;
        private SerializedProperty m_IsComplete;

        #endregion

        private bool elementPropertiesGroup = true;
        private bool elementSaveInfosGroup = true;

        private void OnEnable()
        {
            saveScriptable = target as SaveScriptable;

            m_MiniGameName = serializedObject.FindProperty("miniGameName");
            m_MiniGameBadge = serializedObject.FindProperty("miniGameBadge");
            
            m_GuidID = serializedObject.FindProperty("scriptableSaveElement.guidID");
            m_IsComplete = serializedObject.FindProperty("scriptableSaveElement.isComplete");
        }
        
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.Space(15);

            #region Scriptable Basic Attributes

            elementPropertiesGroup = EditorGUILayout.BeginFoldoutHeaderGroup(elementPropertiesGroup, "Scriptable Basic Attributes");
            if (elementPropertiesGroup)
            {
                EditorGUILayout.PropertyField(m_MiniGameName, new GUIContent("Element Name"));
                if (m_MiniGameName.stringValue != saveScriptable.name)
                {
                    if (GUILayout.Button("Reset MiniGame Name"))
                    {
                        m_MiniGameName.stringValue = saveScriptable.name;
                    }
                }
                EditorGUILayout.PropertyField(m_MiniGameBadge, new GUIContent("MiniGame Badge"));
                
                EditorGUILayout.Space(15);
            }
            EditorGUILayout.EndFoldoutHeaderGroup();

            #endregion

            #region Scriptables Save Infos

            elementSaveInfosGroup = EditorGUILayout.BeginFoldoutHeaderGroup(elementSaveInfosGroup, "Scriptables Save Infos");
            if (elementSaveInfosGroup)
            {
                EditorGUILayout.PropertyField(m_GuidID, new GUIContent("GuidID"));
                if (m_GuidID.stringValue == string.Empty)
                {
                    if (GUILayout.Button("Generate GUID"))
                    {
                        m_GuidID.stringValue = GUID.Generate().ToString();
                    }
                    EditorGUILayout.Space();
                }
                EditorGUILayout.PropertyField(m_IsComplete, new GUIContent("IsComplete"));
                
                EditorGUILayout.Space(15);
            }
            EditorGUILayout.EndFoldoutHeaderGroup();

            #endregion
            
            EditorGUI.EndChangeCheck();
            serializedObject.ApplyModifiedProperties();
        }
    }
}