using DevLocker.Utils;

namespace CIRC.MenuSystem
{
    [System.Serializable]
    public struct MenuContext
    {
        public string title;
        public string desc;

        public SceneReference scene;
    }
}