using Agate.MVC.Base;
using ProjectAdvergame.Message;

namespace ProjectAdvergame.Module.StoneManager
{
    public class StoneManagerConnector : BaseConnector
    {
        private StoneManagerController _stoneManager;

        protected override void Connect()
        {
            Subscribe<BeatAccuracyMessage>(_stoneManager.OnBeatAccuracy);
            Subscribe<OnReadyMessage>(_stoneManager.OnReady);
            Subscribe<StartPlayMessage>(_stoneManager.StartPlay);
            Subscribe<GameOverMessage>(_stoneManager.OnPause);
        }

        protected override void Disconnect()
        {
            Unsubscribe<BeatAccuracyMessage>(_stoneManager.OnBeatAccuracy);
            Unsubscribe<OnReadyMessage>(_stoneManager.OnReady);
            Unsubscribe<StartPlayMessage>(_stoneManager.StartPlay);
            Unsubscribe<GameOverMessage>(_stoneManager.OnPause);
        }
    }
}