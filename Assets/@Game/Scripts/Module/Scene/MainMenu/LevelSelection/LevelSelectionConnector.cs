using Agate.MVC.Base;
using ProjectAdvergame.Message;

namespace ProjectAdvergame.Module.LevelSelection
{
    public class LevelSelectionConnector : BaseConnector
    {
        private LevelSelectionController _levelSelection;

        protected override void Connect()
        {
            Subscribe<ChooseLevelMessage>(_levelSelection.OnChooseLevel);
            Subscribe<UnlockLevelMessage>(_levelSelection.OnUnlockLevel);
        }

        protected override void Disconnect()
        {
            Unsubscribe<ChooseLevelMessage>(_levelSelection.OnChooseLevel);
            Unsubscribe<UnlockLevelMessage>(_levelSelection.OnUnlockLevel);
        }
    }
}