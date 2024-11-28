using UnityEngine;

namespace CIRC.Core.Controllers
{
    public class Logger : ILogSource
    {
        public string Name { get; }
        private static Logger Global => GameController.Logger;
        
        [HideInCallstack]
        public void Log(ILogSource logSource, string message) => Debug.Log($"[{logSource.Name}] {message}", logSource as UnityEngine.Object);
        [HideInCallstack]
        public void Log(string message) => Log(null, message);

        [HideInCallstack]
        public void LogWarning(string message) => LogWarning(null, message);
        [HideInCallstack]
        public void LogWarning(ILogSource logSource,  string message) => Debug.LogWarning($"[{logSource.Name}] {message}", logSource as UnityEngine.Object);
        
        [HideInCallstack]
        public void LogError(string message) => LogError(null, message);
        [HideInCallstack]
        public void LogError(ILogSource logSource, string message) => Debug.LogError($"[{logSource.Name}] {message}", logSource as UnityEngine.Object);
    }
    
    public interface ILogSource
    {
        string Name { get; }
    }
}