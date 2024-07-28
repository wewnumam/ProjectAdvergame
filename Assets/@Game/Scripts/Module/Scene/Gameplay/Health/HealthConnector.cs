using Agate.MVC.Base;
using ProjectAdvergame.Message;

namespace ProjectAdvergame.Module.Health
{
    public class HealthConnector : BaseConnector
    {
        private HealthController _health;

        protected override void Connect()
        {
            Subscribe<BeatAccuracyMessage>(_health.DecreaseHealth);
            Subscribe<AddHealthMessage>(_health.IncreaseHealth);
            Subscribe<GameWinMessage>(_health.OnGameWin);
        }

        protected override void Disconnect()
        {
            Unsubscribe<BeatAccuracyMessage>(_health.DecreaseHealth);
            Unsubscribe<AddHealthMessage>(_health.IncreaseHealth);
            Unsubscribe<GameWinMessage>(_health.OnGameWin);
        }
    }
}