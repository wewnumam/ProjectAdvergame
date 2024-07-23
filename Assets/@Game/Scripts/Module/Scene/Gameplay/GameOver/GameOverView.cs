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

        public void SetCallbacks(UnityAction onPlayAgain)
        {
            playAgainButton.onClick.RemoveAllListeners();
            playAgainButton.onClick.AddListener(onPlayAgain);
        }

        public void Show()
        {
            gameOverPanel.SetActive(true);
        }
    }
}