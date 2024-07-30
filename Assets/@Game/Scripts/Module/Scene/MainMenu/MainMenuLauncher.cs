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

namespace ProjectAdvergame.Scene.MainMenu
{
    public class MainMenuLauncher : SceneLauncher<MainMenuLauncher, MainMenuView>
    {
        public override string SceneName {get {return "MainMenu";}}

        private SaveSystemController _saveSystem;
        private LevelDataController _levelData;

        private QuitController _quit;
        private LevelSelectionController _levelSelection;
        private StatsController _stats;

        protected override IController[] GetSceneDependencies()
        {
            return new IController[] {
                new QuitController(),
                new LevelSelectionController(),
                new StatsController(),
            };
        }

        protected override IConnector[] GetSceneConnectors()
        {
            return new IConnector[] {
                new LevelSelectionConnector(),
                new StatsConnector(),
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

            _view.SetButtonCallback(GoToGameplay);

            _quit.SetView(_view.QuitView);

            _levelSelection.SetLevelCollection(_levelData.Model.LevelCollection);
            _levelSelection.SetUnlockedLevel(_saveSystem.Model.SaveData.UnlockedLevels);
            _levelSelection.SetCurrentHeartCount(_saveSystem.Model.SaveData.CurrentHeartCount);
            _levelSelection.SetView(_view.LevelSelectionView);
            _levelSelection.SetCurrentContent(_saveSystem.Model.SaveData.CurrentLevelName);

            _stats.SetCurrentHeart(_saveSystem.Model.SaveData.CurrentHeartCount);
            _stats.SetCurrentStar(_saveSystem.Model.SaveData.GetTotalStarCount());
            _stats.SetView(_view.StatsView);

            yield return null;
        }

        private void GoToGameplay()
        {
            SceneLoader.Instance.LoadScene("Gameplay");
        }
    }
}
