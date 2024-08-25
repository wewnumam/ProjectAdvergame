using ProjectAdvergame.Boot;
using Agate.MVC.Base;
using Agate.MVC.Core;
using System.Collections;
using UnityEngine.SceneManagement;
using ProjectAdvergame.Message;
using ProjectAdvergame.Module.Quit;
using ProjectAdvergame.Module.LevelSelection;
using ProjectAdvergame.Module.LevelData;
using ProjectAdvergame.Module.SaveSystem;
using UnityEngine;
using ProjectAdvergame.Module.Stats;
using ProjectAdvergame.Utility;
using ProjectAdvergame.Module.CheatFeature;
using ProjectAdvergame.Module.Settings;
using ProjectAdvergame.Module.GameSettings;
using ProjectAdvergame.Module.CharacterData;
using ProjectAdvergame.Module.CharacterSelection;

namespace ProjectAdvergame.Scene.MainMenu
{
    public class MainMenuLauncher : SceneLauncher<MainMenuLauncher, MainMenuView>
    {
        public override string SceneName {get {return TagManager.SCENE_MAINMENU;}}

        private SaveSystemController _saveSystem;
        private LevelDataController _levelData;
        private CharacterDataController _characterData;
        private GameSettingsController _gameSettings;

        private QuitController _quit;
        private LevelSelectionController _levelSelection;
        private CharacterSelectionController _characterSelection;
        private StatsController _stats;
        private CheatFeatureController _cheatFeature;
        private SettingsController _settings;

        protected override IController[] GetSceneDependencies()
        {
            return new IController[] {
                new QuitController(),
                new LevelSelectionController(),
                new CharacterSelectionController(),
                new StatsController(),
                new CheatFeatureController(),
                new SettingsController(),
            };
        }

        protected override IConnector[] GetSceneConnectors()
        {
            return new IConnector[] {
                new LevelSelectionConnector(),
                new CharacterSelectionConnector(),
                new StatsConnector(),
            };
        }

        protected override IEnumerator LaunchScene()
        {
            yield return null;
        }

        protected override IEnumerator InitSceneObject()
        {
            Time.timeScale = 1;

            Publish(new GameStateMessage(Utility.EnumManager.GameState.PreGame));

            SceneManager.SetActiveScene(SceneManager.GetSceneByName(SceneName));

            yield return StartCoroutine(_levelData.SetCurrentLevel(_saveSystem.Model.SaveData.CurrentLevelName));

            _view.SetButtonCallback(GoToGameplay);

            _quit.SetView(_view.QuitView);

            _levelSelection.SetLevelCollection(_levelData.Model.LevelCollection);
            _levelSelection.SetUnlockedLevel(_saveSystem.Model.SaveData.UnlockedLevels);
            _levelSelection.SetCurrentHeartCount(_saveSystem.Model.SaveData.CurrentHeartCount);
            _levelSelection.SetCurrentStarCount(_saveSystem.Model.SaveData.GetTotalStarCount());
            _levelSelection.SetView(_view.LevelSelectionView);
            Publish(new LoadLevelCompleteMessage(
                _saveSystem.Model.SaveData.CurrentLevelName, 
                _levelData.Model.CurrentArtwork, 
                _levelData.Model.CurrentMusicClip, 
                _levelData.Model.CurrentSkybox));

            yield return StartCoroutine(_characterData.SetCurrentCharacter(_saveSystem.Model.SaveData.CurrentCharacterName));

            _characterSelection.SetCharacterCollection(_characterData.Model.CharacterCollection);
            _characterSelection.SetUnlockedCharacters(_saveSystem.Model.SaveData.UnlockedCharacters);
            _characterSelection.SetCurrentHeartCount(_saveSystem.Model.SaveData.CurrentHeartCount);
            _characterSelection.SetCurrentStarCount(_saveSystem.Model.SaveData.GetTotalStarCount());
            _characterSelection.SetView(_view.CharacterSelectionView);
            Publish(new LoadCharacterCompleteMessage(
                _saveSystem.Model.SaveData.CurrentCharacterName,
                _characterData.Model.CurrentCharacterData.fullName,
                _characterData.Model.CurrentPrefab));

            _stats.SetCurrentHeart(_saveSystem.Model.SaveData.CurrentHeartCount);
            _stats.SetCurrentStar(_saveSystem.Model.SaveData.GetTotalStarCount());
            _stats.SetView(_view.StatsView);

            _cheatFeature.SetView(_view.CheatFeatureView);

            _settings.SetInitialVolume(_gameSettings.Model.AudioVolume);
            _settings.SetInitialVibrate(_gameSettings.Model.IsVibrateOn);
            _settings.SetView(_view.SettingsView);

            yield return null;
        }

        private void GoToGameplay()
        {
            SceneLoader.Instance.LoadScene("Gameplay");
        }
    }
}
