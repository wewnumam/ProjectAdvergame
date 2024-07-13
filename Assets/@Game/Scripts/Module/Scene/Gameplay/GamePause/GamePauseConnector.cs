using Agate.MVC.Base;
using ProjectAdvergame.Message;

namespace ProjectAdvergame.Module.GamePause
{
    public class GamePauseConnector : BaseConnector
    {
        private GamePauseController _gamePause;

        protected override void Connect()
        {
            Subscribe<GamePauseMessage>(_gamePause.OnPause);
        }

        protected override void Disconnect()
        {
            Unsubscribe<GamePauseMessage>(_gamePause.OnPause);
        }
    }
}