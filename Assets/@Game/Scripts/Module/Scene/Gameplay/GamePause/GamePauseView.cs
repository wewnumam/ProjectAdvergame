using Agate.MVC.Base;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ProjectAdvergame.Module.GamePause
{
    public class GamePauseView : BaseView
    {
        public Button mainMenuButton;
        public Button playAgainButton;

        [Header("Pause Button")]
        public Button pauseButton;
        public Image pauseIconImage;
        public Sprite pauseSprite;
        public Sprite resumeSprite;


        public void SetCallbacks(UnityAction togglePause, UnityAction onMainMenu, UnityAction onPlayAgain)
        {
            pauseButton.onClick.RemoveAllListeners();
            pauseButton.onClick.AddListener(togglePause);
            
            mainMenuButton.onClick.RemoveAllListeners();
            mainMenuButton.onClick.AddListener(onMainMenu);

            playAgainButton.onClick.RemoveAllListeners();
            playAgainButton.onClick.AddListener(onPlayAgain);
        }
    }
}