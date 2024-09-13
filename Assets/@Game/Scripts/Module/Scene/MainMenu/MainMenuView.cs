using ProjectAdvergame.Boot;
using Agate.MVC.Base;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using ProjectAdvergame.Module.Quit;
using ProjectAdvergame.Module.LevelSelection;
using TMPro;
using ProjectAdvergame.Module.Stats;
using ProjectAdvergame.Module.CheatFeature;
using ProjectAdvergame.Module.Settings;
using ProjectAdvergame.Module.CharacterSelection;
using ProjectAdvergame.Module.Review;

namespace ProjectAdvergame.Scene.MainMenu
{
    public class MainMenuView : BaseSceneView
    {
        public QuitView QuitView;
        public LevelSelectionView LevelSelectionView;
        public CharacterSelectionView CharacterSelectionView;
        public StatsView StatsView;
        public CheatFeatureView CheatFeatureView;
        public SettingsView SettingsView;
        public ReviewView ReviewView;

        public Button playButton;
        public Button screenshotButton;

        public void SetButtonCallback(UnityAction onPlay, UnityAction onScreenshot)
        {
            playButton.onClick.RemoveAllListeners();
            playButton.onClick.AddListener(onPlay);
            screenshotButton.onClick.RemoveAllListeners();
            screenshotButton.onClick.AddListener(onScreenshot);
        }
    }
}
