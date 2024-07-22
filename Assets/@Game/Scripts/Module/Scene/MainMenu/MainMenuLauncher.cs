using ProjectAdvergame.Boot;
using Agate.MVC.Base;
using Agate.MVC.Core;
using System.Collections;
using UnityEngine.SceneManagement;
using ProjectAdvergame.Message;

namespace ProjectAdvergame.Scene.MainMenu
{
    public class MainMenuLauncher : SceneLauncher<MainMenuLauncher, MainMenuView>
    {
        public override string SceneName {get {return "MainMenu";}}

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

            Publish(new GameStateMessage(Utility.EnumManager.GameState.PreGame));

            SceneManager.SetActiveScene(SceneManager.GetSceneByName(SceneName));

            _view.SetButtonCallback(GoToGameplay);
            
            yield return null;
        }

        private void GoToGameplay()
        {
            SceneLoader.Instance.LoadScene("Gameplay");
        }
    }
}
