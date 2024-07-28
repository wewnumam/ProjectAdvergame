using Agate.MVC.Base;
using ProjectAdvergame.Message;

namespace ProjectAdvergame.Module.SaveSystem
{
    public class SaveSystemConnector : BaseConnector
    {
        private SaveSystemController _saveSystem;

        protected override void Connect()
        {
            Subscribe<GameResultHeartMessage>(_saveSystem.SaveHeartResult);
            Subscribe<GameResultStarMessage>(_saveSystem.SaveStarResult);
        }

        protected override void Disconnect()
        {
            Unsubscribe<GameResultHeartMessage>(_saveSystem.SaveHeartResult);
            Unsubscribe<GameResultStarMessage>(_saveSystem.SaveStarResult);
        }
    }
}