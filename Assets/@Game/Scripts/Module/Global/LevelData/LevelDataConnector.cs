using Agate.MVC.Base;
using ProjectAdvergame.Message;

namespace ProjectAdvergame.Module.LevelData
{
    public class LevelDataConnector : BaseConnector
    {
        private LevelDataController _levelData;

        protected override void Connect()
        {
            Subscribe<ChooseLevelMessage>(_levelData.OnChooseLevel);
        }

        protected override void Disconnect()
        {
            Unsubscribe<ChooseLevelMessage>(_levelData.OnChooseLevel);
        }
    }
}