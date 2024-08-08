using ProjectAdvergame.Boot;
using Agate.MVC.Base;
using Agate.MVC.Core;
using System.Collections;
using ProjectAdvergame.Module.Input;
using ProjectAdvergame.Module.PlayerCharacter;
using ProjectAdvergame.Module.StoneManager;
using ProjectAdvergame.Module.CameraManager;
using ProjectAdvergame.Module.BeatAccuracyEvaluator;
using ProjectAdvergame.Module.LevelData;
using UnityEngine.SceneManagement;
using ProjectAdvergame.Module.GamePause;
using ProjectAdvergame.Module.MusicPlayer;
using UnityEngine;
using ProjectAdvergame.Module.Score;
using ProjectAdvergame.Module.GameConstants;
using ProjectAdvergame.Module.Health;
using ProjectAdvergame.Module.GameOver;
using ProjectAdvergame.Module.GameWin;
using ProjectAdvergame.Message;
using ProjectAdvergame.Module.OnReady;
using ProjectAdvergame.Module.SaveSystem;
using ProjectAdvergame.Utility;
using ProjectAdvergame.Module.GameSettings;
using ProjectAdvergame.Module.Settings;

namespace ProjectAdvergame.Scene.Gameplay
{
    public class GameplayLauncher : SceneLauncher<GameplayLauncher, GameplayView>
    {
        public override string SceneName {get {return TagManager.SCENE_GAMEPLAY;}}

        private SaveSystemController _saveSystem;
        private GameConstantsController _gameConstants;
        private LevelDataController _levelData;
        private GameSettingsController _gameSettings;

        private PlayerCharacterController _playerCharacter;
        private StoneManagerController _stoneManager;
        private CameraManagerController _cameraManager;
        private BeatAccuracyEvaluatorController _beatAccuracyEvaluator;
        private MusicPlayerController _musicPlayer;
        private ScoreController _score;
        private HealthController _health;
        private GamePauseController _gamePause;
        private GameOverController _gameOver;
        private GameWinController _gameWin;
        private OnReadyController _onReady;
        private SettingsController _settings;

        protected override IController[] GetSceneDependencies()
        {
            return new IController[] {
                new TapInputController(),
                new PlayerCharacterController(),
                new CameraManagerController(),
                new StoneManagerController(),
                new BeatAccuracyEvaluatorController(),
                new GamePauseController(),
                new MusicPlayerController(),
                new ScoreController(),
                new HealthController(),
                new GameOverController(),
                new GameWinController(),
                new OnReadyController(),
                new SettingsController(),
            };
        }

        protected override IConnector[] GetSceneConnectors()
        {
            return new IConnector[] {
                new PlayerCharacterConnector(),
                new CameraManagerConnector(),
                new StoneManagerConnector(),
                new BeatAccuracyEvaluatorConnector(),
                new GamePauseConnector(),
                new MusicPlayerConnector(),
                new ScoreConnector(),
                new HealthConnector(),
                new GameOverConnector(),
                new GameWinConnector(),
                new OnReadyConnector(),
            };
        }

        protected override IEnumerator LaunchScene()
        {
            yield return null;
        }

        protected override IEnumerator InitSceneObject()
        {
            _levelData.SetCurrentLevel(_saveSystem.Model.SaveData.CurrentLevelName);

            Publish(new GameStateMessage(Utility.EnumManager.GameState.PreGame));

            SceneManager.SetActiveScene(SceneManager.GetSceneByName(SceneName));

            RenderSettings.skybox = _levelData.Model.CurrentLevelData.skybox;

            Instantiate(_levelData.Model.CurrentLevelData.environmentPrefab);

            _playerCharacter.SetView(_view.PlayerCharacterView);
            _cameraManager.SetView(_view.CameraManagerView);

            _stoneManager.SetBeatCollections(_levelData.Model.CurrentLevelData.beats);
            _stoneManager.SetView(_view.StoneManagerView);

            _beatAccuracyEvaluator.SetMinPerfectTapPhase(_gameConstants.Model.GameConstants.minPerfectTapPhase);
            _beatAccuracyEvaluator.SetBeatCollections(_levelData.Model.CurrentLevelData.beats);
            _beatAccuracyEvaluator.SetVibrate(_gameSettings.Model.IsVibrateOn);
            _beatAccuracyEvaluator.SetView(_view.BeatAccuracyEvaluatorView);
            
            _musicPlayer.SetMusicClip(_levelData.Model.CurrentLevelData.musicClip);
            _musicPlayer.SetView(_view.MusicPlayerView);

            _score.SetBeatCollections(_levelData.Model.CurrentLevelData.beats);
            _score.SetScoreEarlyAmount(_gameConstants.Model.GameConstants.scoreEarlyAmount);
            _score.SetScorePerfectAmount(_gameConstants.Model.GameConstants.scorePerfectAmount);
            _score.SetScoreLateAmount(_gameConstants.Model.GameConstants.scoreLateAmount);
            _score.SetView(_view.ScoreView);

            _health.SetCurrentHealth(_gameConstants.Model.GameConstants.initialHealth);
            _health.SetView(_view.HealthView);

            _gamePause.SetView(_view.GamePauseView);

            _gameOver.SetView(_view.GameOverView);

            _gameWin.SetView(_view.GameWinView);

            _onReady.SetView(_view.OnReadyView);
            _onReady.SetOnReadyCountdown(_gameConstants.Model.GameConstants.onReadyCountdown);

            _settings.SetInitialVolume(_gameSettings.Model.AudioVolume);
            _settings.SetInitialVibrate(_gameSettings.Model.IsVibrateOn);
            _settings.SetView(_view.SettingsView);

            yield return null;
        }
    }
}
