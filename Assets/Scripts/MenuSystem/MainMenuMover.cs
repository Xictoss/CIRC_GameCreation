using System;
using System.Collections;
using CIRC.Collections;
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
            if (!MenuManager.HasInstance) return;
            
            MenuManager.Instance.OnMenuClose -= MenuClose;
            MenuManager.Instance.OnMenuOpen -= MenuOpen;
        }

        //EXPENSIVE ?
        private IEnumerator Start()
        {
            yield return new WaitForSeconds(1f);
            MenuClose();
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
}