using Agate.MVC.Base;
using ProjectAdvergame.Message;

namespace ProjectAdvergame.Module.CharacterSelection
{
    public class CharacterSelectionConnector : BaseConnector
    {
        private CharacterSelectionController _characterSelection;

        protected override void Connect()
        {
            Subscribe<LoadCharacterCompleteMessage>(_characterSelection.OnLoadCharacterComplete);
            Subscribe<UnlockCharacterMessage>(_characterSelection.OnUnlockCharacter);
            Subscribe<LoadProgressMessage>(_characterSelection.OnLoadProgress);
        }

        protected override void Disconnect()
        {
            Unsubscribe<LoadCharacterCompleteMessage>(_characterSelection.OnLoadCharacterComplete);
            Unsubscribe<UnlockCharacterMessage>(_characterSelection.OnUnlockCharacter);
            Unsubscribe<LoadProgressMessage>(_characterSelection.OnLoadProgress);
        }
    }
}