using CIRC.Core.Scriptables.Core;
using UnityEditor;
using UnityEngine;

namespace CIRC.Core.Scriptables.Editor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(BadgeScriptable))]
    public class BadgeScriptableEditor : UnityEditor.Editor
    {
        private SaveScriptable _saveScriptable;

        #region SerializedProperties

        private SerializedProperty _badgeName;
        private SerializedProperty _badgeDisplayImage;
        
        private SerializedProperty _guidID;
        private SerializedProperty _isComplete;

        #endregion

        private bool elementPropertiesGroup = true;
        private bool elementSaveInfosGroup = true;

        private void OnEnable()
        {
            _saveScriptable = target as SaveScriptable;

            _badgeName = serializedObject.FindProperty("BadgeName");
            _badgeDisplayImage = serializedObject.FindProperty("BadgeDisplayImage");
            
            _guidID = serializedObject.FindProperty("ScriptableSaveElement.GuidID");
            _isComplete = serializedObject.FindProperty("ScriptableSaveElement.IsComplete");
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
                EditorGUILayout.PropertyField(_badgeName, new GUIContent("Element Name"));
                if (_badgeName.stringValue != _saveScriptable.name)
                {
                    if (GUILayout.Button("Reset Element Name"))
                    {
                        _badgeName.stringValue = _saveScriptable.name;
                    }
                }
                EditorGUILayout.PropertyField(_badgeDisplayImage, new GUIContent("Badge Illustration"));
                
                EditorGUILayout.Space(15);
            }
            EditorGUILayout.EndFoldoutHeaderGroup();

            #endregion

            #region Scriptables Save Infos

            elementSaveInfosGroup = EditorGUILayout.BeginFoldoutHeaderGroup(elementSaveInfosGroup, "Scriptables Save Infos");
            if (elementSaveInfosGroup)
            {
                EditorGUILayout.PropertyField(_guidID, new GUIContent("GuidID"));
                if (_guidID.stringValue == string.Empty)
                {
                    if (GUILayout.Button("Generate GUID"))
                    {
                        _guidID.stringValue = GUID.Generate().ToString();
                    }
                    EditorGUILayout.Space();
                }
                EditorGUILayout.PropertyField(_isComplete, new GUIContent("IsComplete"));
                
                EditorGUILayout.Space(15);
            }
            EditorGUILayout.EndFoldoutHeaderGroup();

            #endregion
            
            EditorGUI.EndChangeCheck();
            serializedObject.ApplyModifiedProperties();
        }
    }
}