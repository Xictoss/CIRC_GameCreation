using DG.Tweening;
using UnityEngine;

namespace CIRC.MenuSystem
{
    public class MainMenuMover : MonoBehaviour
    {
        [SerializeField] private MenuMoveLink[] menus;
        [SerializeField] private PriorityScale targetPriority;
        
        private void OnEnable()
        {
            MenuManager.Instance.OnMenuClose += MenuClose;
            MenuManager.Instance.OnMenuOpen += MenuOpen;
        }

        private void OnDisable()
        {
            MenuManager.Instance.OnMenuClose -= MenuClose;
            MenuManager.Instance.OnMenuOpen -= MenuOpen;
        }

        private bool IsPriorityHigher(PriorityScale menuPriority)
        {
            return menuPriority >= targetPriority;
        }
        
        private void MenuClose()
        {
            if (MenuManager.Instance.currentMenu == null)
            {
                for (int i = 0; i < menus.Length; i++)
                {
                    MenuMoveLink link = menus[i];
                    MoveMenu(link.menuTransform, link.targetTransformOn, link.moveDuration);
                }
            }
        }

        private void MenuOpen(BaseMenu menu)
        {
            if (IsPriorityHigher(menu.PriorityScale))
            {
                for (int i = 0; i < menus.Length; i++)
                {
                    MenuMoveLink link = menus[i];
                    MoveMenu(link.menuTransform, link.targetTransformOff, link.moveDuration);
                }
            }
        }

        private void MoveMenu(Transform menu, Transform target, float moveDuration)
        {
            menu.DOMove(target.position, moveDuration)
                .SetEase(Ease.InOutCirc);
        }
    }

    [System.Serializable]
    public struct MenuMoveLink
    {
        public Transform menuTransform;
        public Transform targetTransformOn;
        public Transform targetTransformOff;
        public float moveDuration;
    }
}