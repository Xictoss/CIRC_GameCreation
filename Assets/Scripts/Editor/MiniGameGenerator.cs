using System.IO;
using UnityEditor;
using UnityEngine;

public class MiniGameGenerator : EditorWindow
{
    private string miniGameName = "NewMiniGame";

    private void OnGUI()
    {
        GUILayout.Label("Mini-Game Generator", EditorStyles.boldLabel);

        miniGameName = EditorGUILayout.TextField("Mini-Game Name", miniGameName);

        if (GUILayout.Button("Generate Mini-Game Files")) GenerateMiniGameFiles();
    }

    [MenuItem("Tools/Mini-Game Generator")]
    public static void ShowWindow()
    {
        GetWindow<MiniGameGenerator>("Mini-Game Generator");
    }

    private void GenerateMiniGameFiles()
    {
        if (string.IsNullOrWhiteSpace(miniGameName))
        {
            Debug.LogError("Mini-Game name cannot be empty!");
            return;
        }

        var rootPath = Path.Combine(Application.dataPath, "Scripts/Core/MiniGames/Sample", miniGameName);

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
            return ;
        }

        public override void End(ref {CLASS_NAME}Context context, bool isSuccess)
        {
            if (isSuccess)
            {
                context.miniGameData.ScriptableSaveElement.IsComplete = true;
                context.miniGameData.MiniGameBadge.ScriptableSaveElement.IsComplete = true;
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
using CIRC.Core.Scriptables.Core;
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
using CIRC.Core.Scriptables.Core;

namespace CIRC.Core.MiniGames.Sample.{CLASS_NAME}
{
    public struct {CLASS_NAME}Context : IMiniGameContext
    {
        public MiniGameData miniGameData;
    }
}".Replace("{CLASS_NAME}", miniGameName);
    }
}