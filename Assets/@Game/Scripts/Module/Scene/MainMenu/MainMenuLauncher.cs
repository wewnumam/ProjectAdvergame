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

namespace ProjectAdvergame.Scene.MainMenu
{
    public class MainMenuLauncher : SceneLauncher<MainMenuLauncher, MainMenuView>
    {
        public override string SceneName {get {return "MainMenu";}}

        private SaveSystemController _saveSystem;
        private LevelDataController _levelData;

        private QuitController _quit;
        private LevelSelectionController _levelSelection;

        protected override IController[] GetSceneDependencies()
        {
            return new IController[] {
                new QuitController(),
                new LevelSelectionController(),
            };
        }

        protected override IConnector[] GetSceneConnectors()
        {
            return new IConnector[] {
                new LevelSelectionConnector(),
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

            _view.currentLevelText.SetText(_saveSystem.Model.SaveData.CurrentLevelName);
            _view.SetButtonCallback(GoToGameplay);

            _quit.SetView(_view.QuitView);

            _levelSelection.SetLevelCollection(_levelData.Model.LevelCollection);
            _levelSelection.SetView(_view.LevelSelectionView);
            
            yield return null;
        }

        private void GoToGameplay()
        {
            SceneLoader.Instance.LoadScene("Gameplay");
        }
    }
}
