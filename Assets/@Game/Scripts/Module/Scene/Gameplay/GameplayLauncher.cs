using ProjectAdvergame.Boot;
using Agate.MVC.Base;
using Agate.MVC.Core;
using System.Collections;
using ProjectAdvergame.Module.Input;
using ProjectAdvergame.Module.PlayerCharacter;
using ProjectAdvergame.Module.StoneManager;
using ProjectAdvergame.Module.CameraManager;

namespace ProjectAdvergame.Scene.Gameplay
{
    public class GameplayLauncher : SceneLauncher<GameplayLauncher, GameplayView>
    {
        public override string SceneName {get {return "Gameplay";}}

        private PlayerCharacterController _playerCharacter;
        private StoneManagerController _stoneManager;
        private CameraManagerController _cameraManager;

        protected override IController[] GetSceneDependencies()
        {
            return new IController[] {
                new TapInputController(),
                new PlayerCharacterController(),
                new CameraManagerController(),
                new StoneManagerController(),
            };
        }

        protected override IConnector[] GetSceneConnectors()
        {
            return new IConnector[] {
                new PlayerCharacterConnector(),
                new CameraManagerConnector(),
                new StoneManagerConnector(),
            };
        }

        protected override IEnumerator LaunchScene()
        {
            yield return null;
        }

        protected override IEnumerator InitSceneObject()
        {
            _view.SetButtonCallback(GoToGameplay);

            _playerCharacter.SetView(_view.PlayerCharacterView);
            _cameraManager.SetView(_view.CameraManagerView);
            _stoneManager.SetView(_view.StoneManagerView);

            yield return null;
        }

        private void GoToGameplay()
        {
            SceneLoader.Instance.LoadScene("MainMenu");
        }
    }
}
