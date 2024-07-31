using Agate.MVC.Base;
using ProjectAdvergame.Boot;
using ProjectAdvergame.Message;
using ProjectAdvergame.Utility;
using System;

namespace ProjectAdvergame.Module.GameOver
{
    public class GameOverController : ObjectController<GameOverController, GameOverView>
    {
        public override void SetView(GameOverView view)
        {
            base.SetView(view);
            view.SetCallbacks(OnPlayAgain, OnMainMenu);
        }

        private void OnPlayAgain() => SceneLoader.Instance.RestartScene();

        private void OnMainMenu() => SceneLoader.Instance.LoadScene(TagManager.SCENE_MAINMENU);

        internal void OnGameOver(GameOverMessage message)
        {
            Publish(new GameStateMessage(Utility.EnumManager.GameState.GameOver));
            _view.Show();
        }
    }
}