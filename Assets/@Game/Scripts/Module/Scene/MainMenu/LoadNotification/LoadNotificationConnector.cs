using Agate.MVC.Base;
using ProjectAdvergame.Message;

namespace ProjectAdvergame.Module.LoadNotification
{
    public class LoadNotificationConnector : BaseConnector
    {
        private LoadNotificationController _loadNotification;

        protected override void Connect()
        {
            Subscribe<OnFailedToLoadAssetMessage>(_loadNotification.Show);
        }

        protected override void Disconnect()
        {
            Unsubscribe<OnFailedToLoadAssetMessage>(_loadNotification.Show);
        }
    }
}