using System;
using System.Linq;
using System.Reflection;
using CIRC.Controllers;
using DevLocker.Utils;
using NaughtyAttributes;
using UnityEngine;

namespace CIRC.MenuSystem
{
    public class SceneChanger : MonoBehaviour
    {
        [SerializeField]
#if UNITY_EDITOR  
        [Dropdown(nameof(GetSceneReferences))]
#endif
        protected SceneReference sceneIndex;

#if UNITY_EDITOR  
        private DropdownList<SceneReference> GetSceneReferences()
        {
            Type t = typeof(GameMetrics);
            PropertyInfo[] properties = t.GetProperties();
            DropdownList<SceneReference> list = new();
            for (int i = 0; i < properties.Length; i++)
            {
                PropertyInfo p = properties[i];
                if(p.PropertyType != typeof(SceneReference))
                    continue;
                
                object value = p.GetValue(GameMetrics.Global);
                if (value is SceneReference sceneReference)
                    list.Add(sceneReference.SceneName, sceneReference);
            }

            if(!list.Any())
                list.Add("None", null);
            
            return list;
        }
#endif

        public virtual void ChangeScene()
        {
            GameController.SceneController.LoadScene(sceneIndex);
        }
    }
}