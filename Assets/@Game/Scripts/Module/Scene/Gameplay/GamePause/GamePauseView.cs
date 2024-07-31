using Agate.MVC.Base;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ProjectAdvergame.Module.GamePause
{
    public class GamePauseView : BaseView
    {
        public Button mainMenuButton;
        public GameObject pausePanel;

        [Header("Pause Button")]
        public Button pauseButton;
        public Image pauseIconImage;
        public Sprite pauseSprite;
        public Sprite resumeSprite;


        public void SetCallbacks(UnityAction togglePause, UnityAction onMainMenu)
        {
            pauseButton.onClick.RemoveAllListeners();
            pauseButton.onClick.AddListener(togglePause);
            
            mainMenuButton.onClick.RemoveAllListeners();
            mainMenuButton.onClick.AddListener(onMainMenu);
        }
    }
}