using CIRC.Collections;
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
        private ValueSortedList<ILoadScene, PriorityScale> subbedClasses = new ValueSortedList<ILoadScene, PriorityScale>();
        
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
            if (subbedClasses.TryAdd(classToSub, priority))
            {
                //Debug.Log($"Added {classToSub} to List with a priority of {(int)priority}");
            }
            else
            {
                Debug.Log($"Class {classToSub} already exists in the list");
            }
        }

        public void RemoveSubbedClass(ILoadScene obj)
        {
            if (subbedClasses.ContainsKey(obj))
            {
                subbedClasses.TryRemove(obj);
            }
        }
        
        public void OnSceneChanged(Scene currentScene, Scene nextScene)
        {
            foreach (ILoadScene subbedClass in subbedClasses.GetKeys())
            {
                //Debug.Log(subbedClass);
                subbedClass.OnSceneLoaded(previousScene, nextScene);
            }
        }
    }
}