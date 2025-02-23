using CIRC.Collections;
using CIRC.Controllers;
using DevLocker.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace CIRC.MenuSystem
{
    public class LevelsMenu : BaseMenu
    {
        [SerializeField] private SceneReference[] levelScenes;
        [SerializeField] private Sprite[] levelSprites;
        [SerializeField] private Image[] selectedLevels;
        [SerializeField] private Image levelImage;
        private int currentLevel;

        private Color colorOn => new Color(255, 255, 255, 1);
        private Color colorOff => new Color(255, 255, 255, 0);
        
        public void SwitchLevel(int direction)
        {
            selectedLevels[currentLevel].color = colorOff;
            
            currentLevel += direction;
            currentLevel = currentLevel < 0 ? 5 : currentLevel > 5 ? 0 : currentLevel;

            levelImage.sprite = levelSprites[currentLevel];
            selectedLevels[currentLevel].color = colorOn;
        }

        public void PlayLevel()
        {
            MenuManager.Instance.TryCloseMenu(MenuName);
            GameController.SceneController.LoadScene(levelScenes[currentLevel]);
        }
        
        public override void OpenMenu(MenuContext ctx)
        {
            for (int i = 0; i < selectedLevels.Length; i++)
            {
                selectedLevels[i].color = colorOff;
            }
            SwitchLevel(0);
            gameObject.SetActive(true);
        }

        public override void CloseMenu()
        {
            gameObject.SetActive(false);
        }

        public override string MenuName => GameController.Metrics.LevelsMenu;
        public override PriorityScale PriorityScale => PriorityScale.Medium;
        public override GameObject Object => gameObject;
    }
}