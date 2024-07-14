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

namespace ProjectAdvergame.Scene.Gameplay
{
    public class GameplayLauncher : SceneLauncher<GameplayLauncher, GameplayView>
    {
        public override string SceneName {get {return "Gameplay";}}

        private LevelDataController _levelData;

        private PlayerCharacterController _playerCharacter;
        private StoneManagerController _stoneManager;
        private CameraManagerController _cameraManager;
        private BeatAccuracyEvaluatorController _beatAccuracyEvaluator;
        private MusicPlayerController _musicPlayer;

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
            };
        }

        protected override IEnumerator LaunchScene()
        {
            yield return null;
        }

        protected override IEnumerator InitSceneObject()
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(SceneName));

            _view.SetButtonCallback(GoToGameplay);

            _playerCharacter.SetView(_view.PlayerCharacterView);
            _cameraManager.SetView(_view.CameraManagerView);

            _stoneManager.SetBeatCollections(_levelData.Model.CurrentLevelData.beatCollections);
            _stoneManager.SetView(_view.StoneManagerView);

            _beatAccuracyEvaluator.SetBeatCollections(_levelData.Model.CurrentLevelData.beatCollections);
            _beatAccuracyEvaluator.SetView(_view.BeatAccuracyEvaluatorView);
            
            _musicPlayer.SetMusicClip(_levelData.Model.CurrentLevelData.musicClip);
            _musicPlayer.SetView(_view.MusicPlayerView);

            yield return null;
        }

        private void GoToGameplay()
        {
            SceneLoader.Instance.LoadScene("MainMenu");
        }
    }
}
