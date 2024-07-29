using Agate.MVC.Base;
using ProjectAdvergame.Message;

namespace ProjectAdvergame.Module.Stats
{
    public class StatsConnector : BaseConnector
    {
        private StatsController _stats;

        protected override void Connect()
        {
            Subscribe<UnlockLevelMessage>(_stats.OnUnlockLevel);
        }

        protected override void Disconnect()
        {
            Unsubscribe<UnlockLevelMessage>(_stats.OnUnlockLevel);
        }
    }
}