using Agate.MVC.Base;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ProjectAdvergame.Module.GameOver
{
    public class GameOverView : BaseView
    {
        [SerializeField] GameObject gameOverPanel;
        [SerializeField] Button playAgainButton;
        [SerializeField] Button mainMenuButton;

        public void SetCallbacks(UnityAction onPlayAgain, UnityAction onMainMenu)
        {
            playAgainButton.onClick.RemoveAllListeners();
            playAgainButton.onClick.AddListener(onPlayAgain);
            mainMenuButton.onClick.RemoveAllListeners();
            mainMenuButton.onClick.AddListener(onMainMenu);
        }

        public void Show()
        {
            gameOverPanel.SetActive(true);
        }
    }
}