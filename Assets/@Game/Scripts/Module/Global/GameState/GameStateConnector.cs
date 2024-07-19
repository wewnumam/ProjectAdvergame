using Agate.MVC.Base;
using ProjectAdvergame.Message;

namespace ProjectAdvergame.Module.GameState
{
    public class GameStateConnector : BaseConnector
    {
        private GameStateController _gameState;

        protected override void Connect()
        {
            Subscribe<GameStateMessage>(_gameState.SetGameState);
        }

        protected override void Disconnect()
        {
            Unsubscribe<GameStateMessage>(_gameState.SetGameState);
        }
    }
}