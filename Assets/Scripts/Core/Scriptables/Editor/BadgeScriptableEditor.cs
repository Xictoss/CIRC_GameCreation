using NomDuJeu.Scriptables.Core;
using UnityEditor;
using UnityEngine;

namespace NomDuJeu.Scriptables.Editor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(BadgeScriptable))]
    public class BadgeScriptableEditor : UnityEditor.Editor
    {
        private SaveScriptable saveScriptable;

        #region SerializedProperties

        private SerializedProperty m_BadgeName;
        private SerializedProperty m_BadgeDisplayImage;
        
        private SerializedProperty m_GuidID;
        private SerializedProperty m_IsComplete;

        #endregion

        private bool elementPropertiesGroup = true;
        private bool elementSaveInfosGroup = true;

        private void OnEnable()
        {
            saveScriptable = target as SaveScriptable;

            m_BadgeName = serializedObject.FindProperty("badgeName");
            m_BadgeDisplayImage = serializedObject.FindProperty("badgeDisplayImage");
            
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
                EditorGUILayout.PropertyField(m_BadgeName, new GUIContent("Element Name"));
                if (m_BadgeName.stringValue != saveScriptable.name)
                {
                    if (GUILayout.Button("Reset Element Name"))
                    {
                        m_BadgeName.stringValue = saveScriptable.name;
                    }
                }
                EditorGUILayout.PropertyField(m_BadgeDisplayImage, new GUIContent("Badge Illustration"));
                
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