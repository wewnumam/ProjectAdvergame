using Agate.MVC.Base;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ProjectAdvergame.Module.GameWin
{
    public class GameWinView : BaseView
    {
        public GameObject gameWinPanel;
        public List<Image> starImages;
        public TMP_Text heartResultText;
        public Button mainMenuButton;
        public Button replayButton;

        public void SetCallbacks(UnityAction onMainMenu, UnityAction onReplay)
        {
            mainMenuButton.onClick.RemoveAllListeners();
            mainMenuButton.onClick.AddListener(onMainMenu);
            replayButton.onClick.RemoveAllListeners();
            replayButton.onClick.AddListener(onReplay);
        }
    }
}