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

        public Button playButton;

        public void SetButtonCallback(UnityAction onPlay)
        {
            playButton.onClick.RemoveAllListeners();
            playButton.onClick.AddListener(onPlay);
        }
    }
}
