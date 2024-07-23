using Agate.MVC.Base;
using ProjectAdvergame.Boot;
using ProjectAdvergame.Message;
using System;

namespace ProjectAdvergame.Module.GameOver
{
    public class GameOverController : ObjectController<GameOverController, GameOverView>
    {
        public override void SetView(GameOverView view)
        {
            base.SetView(view);
            view.SetCallbacks(OnPlayAgain);
        }

        private void OnPlayAgain()
        {
            SceneLoader.Instance.RestartScene();
        }

        internal void OnGameOver(GameOverMessage message)
        {
            Publish(new GameStateMessage(Utility.EnumManager.GameState.GameOver));
            _view.Show();
        }
    }
}