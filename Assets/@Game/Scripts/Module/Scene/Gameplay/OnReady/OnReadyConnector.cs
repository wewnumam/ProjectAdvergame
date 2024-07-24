using Agate.MVC.Base;
using ProjectAdvergame.Message;

namespace ProjectAdvergame.Module.OnReady
{
    public class OnReadyConnector : BaseConnector
    {
        private OnReadyController _onReady;

        protected override void Connect()
        {
            Subscribe<OnReadyMessage>(_onReady.OnReady);
        }

        protected override void Disconnect()
        {
            Unsubscribe<OnReadyMessage>(_onReady.OnReady);
        }
    }
}