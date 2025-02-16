using System.Collections.Generic;
using System.Linq;
using CIRC.Controllers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CIRC.SceneManagement
{
    public class SceneController
    {
        public SceneController Global => GameController.SceneController;
        public string previousScene { get; private set; }
        private SortedList<PriorityScale, ILoadScene> subbedClasses = new SortedList<PriorityScale, ILoadScene>();
        
        public void LoadScene(int sceneIndex)
        {
            previousScene = SceneManager.GetActiveScene().path;
            SceneManager.LoadScene(sceneIndex);
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
        
        public void OnSceneChanged(Scene scene, LoadSceneMode loadSceneMode)
        {
            foreach (ILoadScene subbedClass in subbedClasses.Values.Reverse())
            {
                subbedClass.OnSceneLoaded(scene, loadSceneMode);
            }
        }
    }
}