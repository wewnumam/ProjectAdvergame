using ProjectAdvergame.Boot;
using Agate.MVC.Base;
using Agate.MVC.Core;
using System.Collections;

namespace ProjectAdvergame.Scene.Gameplay
{
    public class GameplayLauncher : SceneLauncher<GameplayLauncher, GameplayView>
    {
        public override string SceneName {get {return "Gameplay";}}

        protected override IController[] GetSceneDependencies()
        {
            return null;
        }

        protected override IConnector[] GetSceneConnectors()
        {
            return null;
        }

        protected override IEnumerator LaunchScene()
        {
            yield return null;
        }

        protected override IEnumerator InitSceneObject()
        {
            _view.SetButtonCallback(GoToGameplay);
            yield return null;
        }

        private void GoToGameplay()
        {
            SceneLoader.Instance.LoadScene("MainMenu");
        }
    }
}
