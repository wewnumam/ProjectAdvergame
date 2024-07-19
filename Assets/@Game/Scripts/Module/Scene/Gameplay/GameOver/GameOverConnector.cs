using Agate.MVC.Base;
using ProjectAdvergame.Message;

namespace ProjectAdvergame.Module.GameOver
{
    public class GameOverConnector : BaseConnector
    {
        private GameOverController _gameOver;

        protected override void Connect()
        {
            Subscribe<GameOverMessage>(_gameOver.OnGameOver);
        }

        protected override void Disconnect()
        {
            Unsubscribe<GameOverMessage>(_gameOver.OnGameOver);
        }
    }
}