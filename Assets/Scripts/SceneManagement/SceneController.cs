using System.Collections.Generic;
using System.Linq;
using CIRC.Controllers;
using DevLocker.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CIRC.SceneManagement
{
    public class SceneController
    {
        public SceneController Global => GameController.SceneController;
        public string previousScene { get; private set; } = "";
        private SortedList<PriorityScale, ILoadScene> subbedClasses = new SortedList<PriorityScale, ILoadScene>();
        
        public void LoadScene(int sceneIndex)
        {
            previousScene = SceneManager.GetActiveScene().path;
            SceneManager.LoadScene(sceneIndex);
        }
        
        public void LoadScene(string sceneName)
        {
            previousScene = SceneManager.GetActiveScene().path;
            SceneManager.LoadScene(sceneName);
        }
        
        public void LoadScene(SceneReference scene)
        {
            previousScene = SceneManager.GetActiveScene().path;
            SceneManager.LoadScene(scene.BuildIndex);
        }

        public void SubToSceneChange(ILoadScene classToSub, PriorityScale priority)
        {
            if (subbedClasses.TryAdd(priority, classToSub))
            {
                Debug.Log($"Added {classToSub} to List with a priority of {(int)priority}");
            }
            else
            {
                Debug.Log($"Class {classToSub} already exists in the list");
            }
        }

        public void RemoveSubbedClass(PriorityScale priority)
        {
            if (subbedClasses.ContainsKey(priority))
            {
                subbedClasses.Remove(priority);
            }
        }
        
        public void OnSceneChanged(Scene currentScene, Scene nextScene)
        {
            foreach (ILoadScene subbedClass in subbedClasses.Values.Reverse())
            {
                subbedClass.OnSceneLoaded(previousScene, nextScene);
            }
        }
    }
}