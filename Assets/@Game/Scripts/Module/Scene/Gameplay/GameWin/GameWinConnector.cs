using Agate.MVC.Base;
using ProjectAdvergame.Message;

namespace ProjectAdvergame.Module.GameWin
{
    public class GameWinConnector : BaseConnector
    {
        private GameWinController _gameWin;

        protected override void Connect()
        {
            Subscribe<GameWinMessage>(_gameWin.OnGameWin);
            Subscribe<GameResultHeartMessage>(_gameWin.ShowHeartResult);
            Subscribe<GameResultStarMessage>(_gameWin.ShowStarResult);
            Subscribe<GameResultScoreMessage>(_gameWin.ShowScoreResult);
        }

        protected override void Disconnect()
        {
            Unsubscribe<GameWinMessage>(_gameWin.OnGameWin);
            Unsubscribe<GameResultHeartMessage>(_gameWin.ShowHeartResult);
            Unsubscribe<GameResultStarMessage>(_gameWin.ShowStarResult);
            Unsubscribe<GameResultScoreMessage>(_gameWin.ShowScoreResult);
        }
    }
}