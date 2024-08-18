using Agate.MVC.Base;
using ProjectAdvergame.Utility;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ProjectAdvergame.Module.GameWin
{
    public class GameWinView : BaseView
    {
        public List<Image> starImages;
        public TMP_Text heartResultText;
        public TMP_Text scoreText;
        public ParticleSystem newHighScoreParticle;
        public Button mainMenuButton;
        public Button replayButton;
        public Color winColor;

        public Tweener_ShowList tweener;

        public void SetCallbacks(UnityAction onMainMenu, UnityAction onReplay)
        {
            mainMenuButton.onClick.RemoveAllListeners();
            mainMenuButton.onClick.AddListener(onMainMenu);
            replayButton.onClick.RemoveAllListeners();
            replayButton.onClick.AddListener(onReplay);
        }
    }
}