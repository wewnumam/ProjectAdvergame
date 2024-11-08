using Agate.MVC.Base;
using ProjectAdvergame.Message;

namespace ProjectAdvergame.Module.LevelSelection
{
    public class LevelSelectionConnector : BaseConnector
    {
        private LevelSelectionController _levelSelection;

        protected override void Connect()
        {
            Subscribe<LoadLevelCompleteMessage>(_levelSelection.OnLoadLevelComplete);
            Subscribe<UnlockLevelMessage>(_levelSelection.OnUnlockLevel);
            Subscribe<LoadProgressMessage>(_levelSelection.OnLoadProgress);
        }

        protected override void Disconnect()
        {
            Unsubscribe<LoadLevelCompleteMessage>(_levelSelection.OnLoadLevelComplete);
            Unsubscribe<UnlockLevelMessage>(_levelSelection.OnUnlockLevel);
            Unsubscribe<LoadProgressMessage>(_levelSelection.OnLoadProgress);
        }
    }
}