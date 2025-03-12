using DevLocker.Utils;
using UnityEngine;

namespace CIRC.MenuSystem
{
    [System.Serializable]
    public struct MenuContext
    {
        public string title;
        public string desc;
        public Sprite image;

        public string endDesc;
        public string endExplication;

        public SceneReference scene;
    }
}