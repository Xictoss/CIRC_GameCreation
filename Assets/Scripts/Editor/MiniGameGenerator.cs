using System;
using System.IO;
using CIRC.Core.Progression.Core.Data;
using CIRC.Core.Progression.Core.Enums;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameGenerator : EditorWindow
{
    private string miniGameName = "NewMiniGame";
    private GameSubject miniGameSubject;
    private BadgeData gameBadge;

    private void OnGUI()
    {
        miniGameName = EditorGUILayout.TextField("Mini-Game Name", miniGameName);
        miniGameSubject = (GameSubject)EditorGUILayout.EnumPopup("Mini-Game Subject", miniGameSubject);
        gameBadge = (BadgeData)EditorGUILayout.ObjectField("Game Badge", gameBadge, typeof(BadgeData), false);
        
        if (string.IsNullOrWhiteSpace(miniGameName))
        {
            Debug.LogError("Mini-Game name cannot be empty!");
            return;
        }

        GUILayout.Space(25);
        
        if (GUILayout.Button("Generate Mini-Game SO")) CreateScriptableObject();
        if (GUILayout.Button("Generate Mini-Game Scripts")) GenerateMiniGameFiles();
        if (GUILayout.Button("Generate Mini-Game Scene")) GenerateMiniGameScene();
    }

    [MenuItem("Tools/Mini-Game Generator")]
    public static void ShowWindow()
    {
        GetWindow<MiniGameGenerator>("Mini-Game Generator");
    }
    
    private void CreateScriptableObject()
    {
        // Create a new instance of the ScriptableObject
        MiniGameData newMiniGameData = CreateInstance<MiniGameData>();
        newMiniGameData.SetName(miniGameName);
        newMiniGameData.SetSubject(miniGameSubject);
        newMiniGameData.SetBadge(gameBadge);

        // Save it as an asset in the project
        string path = $"Assets/Resources/SaveScriptables/MiniGames/{miniGameName}.asset";
        AssetDatabase.CreateAsset(newMiniGameData, path);
        AssetDatabase.SaveAssets();

        // Focus the Project window on the new asset
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = newMiniGameData;

        Debug.Log($"Created ScriptableObject at {path}");
    }

    private void GenerateMiniGameFiles()
    {
        string rootPath = Path.Combine(Application.dataPath, "Scripts/Core/MiniGames/Sample", miniGameName);

        // Create the directory
        if (!Directory.Exists(rootPath)) Directory.CreateDirectory(rootPath);

        // Create files
        CreateFile(rootPath, $"{miniGameName}.cs", GetGameControllerTemplate());
        CreateFile(rootPath, $"{miniGameName}Handler.cs", GetGameHandlerTemplate());
        CreateFile(rootPath, $"{miniGameName}Context.cs", GetGameContextTemplate());

        // Refresh Asset Database
        AssetDatabase.Refresh();

        Debug.Log($"Mini-Game '{miniGameName}' created successfully!");
    }

    private void GenerateMiniGameScene()
    {
        Scene newScene = EditorSceneManager.NewScene(NewSceneSetup.DefaultGameObjects);
        newScene.name = "MiniGameScene";

        GameObject miniGameHandlerObject = new GameObject("MiniGame Manager");

        string componentName = $"CIRC.Core.MiniGames.Sample.{miniGameName}.{miniGameName}Handler, CIRC.Core.MiniGames.Sample";
        Type componentType = Type.GetType(componentName);
        miniGameHandlerObject.AddComponent(componentType);

        string prefabPath = "Assets/Project/Prefabs/Mini-Game Canvas.prefab";
        GameObject miniGameCanvas = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
        GameObject instantiatedCanvas = PrefabUtility.InstantiatePrefab(miniGameCanvas) as GameObject;

        SceneManager.MoveGameObjectToScene(miniGameHandlerObject, newScene);
        SceneManager.MoveGameObjectToScene(instantiatedCanvas, newScene);
        
        string scenePath = $"Assets/Scenes/MainScenes/MiniGames/{miniGameName}.unity";
        if (File.Exists(scenePath))
        {
            Debug.LogWarning("Already a scene with this name");
            return;
        }
        
        EditorSceneManager.SaveScene(newScene, scenePath);
        Debug.Log("MiniGame scene created with MiniGameHandler object.");
    }

    private void CreateFile(string path, string fileName, string content)
    {
        var filePath = Path.Combine(path, fileName);
        if (!File.Exists(filePath))
            File.WriteAllText(filePath, content);
        else
            Debug.LogWarning($"File '{fileName}' already exists and was not overwritten.");
    }

    private string GetGameControllerTemplate()
    {
        return @"using CIRC.Core.Controllers;
using CIRC.Core.MiniGames.Core;

namespace CIRC.Core.MiniGames.Sample.{CLASS_NAME}
{
    public class {CLASS_NAME} : MiniGame<{CLASS_NAME}Context>
    {
        public override void Begin(ref {CLASS_NAME}Context context)
        {
        }

        public override bool Refresh(ref {CLASS_NAME}Context context)
        {
            return false;
        }

        public override void End(ref {CLASS_NAME}Context context, bool isSuccess)
        {
            if (isSuccess)
            {
                context.miniGameData.SaveElement.IsComplete = true;
                GameController.SaveData.SetPlayerCompleted(context.miniGameData.SaveElement);
                GameController.SavePlayerProgressToPlayerPrefs();
            }

            GameController.SceneController.LoadScene(GameController.Metrics.PlageScene);
        }
    }
}".Replace("{CLASS_NAME}", miniGameName);
    }

    private string GetGameHandlerTemplate()
    {
        return @"using CIRC.Core.MiniGames.Core;
using CIRC.Core.MiniGames.Core.Interfaces;
using CIRC.Core.Progression.Core.Data;
using UnityEngine;

namespace CIRC.Core.MiniGames.Sample.{CLASS_NAME}
{
    public class {CLASS_NAME}Handler : MonoBehaviour, IMiniGameHandler<{CLASS_NAME}Context>
    {
        [SerializeField] private MiniGameData miniGameData;
        
        private {CLASS_NAME} miniGame;
        
        private void Start()
        {
            miniGame = new {CLASS_NAME}();
            MiniGameManager.Instance.StartMiniGame(miniGame, this);
        }
        
        public {CLASS_NAME}Context GetContext()
        {
            return new {CLASS_NAME}Context
            {
                miniGameData = miniGameData,
            };
        }
    }
}".Replace("{CLASS_NAME}", miniGameName);
    }

    private string GetGameContextTemplate()
    {
        return @"using CIRC.Core.MiniGames.Core.Interfaces;
using CIRC.Core.Progression.Core.Data;

namespace CIRC.Core.MiniGames.Sample.{CLASS_NAME}
{
    public struct {CLASS_NAME}Context : IMiniGameContext
    {
        public MiniGameData miniGameData;
    }
}".Replace("{CLASS_NAME}", miniGameName);
    }
}