using CIRC.Core.Scriptables.Core;
using UnityEditor;
using UnityEngine;

namespace CIRC.Core.Scriptables.Editor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(MiniGameData))]
    public class MiniGameScriptableEditor : UnityEditor.Editor
    {
        private SaveScriptable saveScriptable;

        #region SerializedProperties

        private SerializedProperty _miniGameName;
        private SerializedProperty _miniGameBadge;
        
        private SerializedProperty _guidID;
        private SerializedProperty _isComplete;

        #endregion

        private bool elementPropertiesGroup = true;
        private bool elementSaveInfosGroup = true;

        private void OnEnable()
        {
            saveScriptable = target as SaveScriptable;

            _miniGameName = serializedObject.FindProperty("MiniGameName");
            _miniGameBadge = serializedObject.FindProperty("MiniGameBadge");
            
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
                EditorGUILayout.PropertyField(_miniGameName, new GUIContent("Element Name"));
                if (_miniGameName.stringValue != saveScriptable.name)
                {
                    if (GUILayout.Button("Reset MiniGame Name"))
                    {
                        _miniGameName.stringValue = saveScriptable.name;
                    }
                }
                EditorGUILayout.PropertyField(_miniGameBadge, new GUIContent("MiniGame Badge"));
                
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