using Agate.MVC.Base;
using ProjectAdvergame.Message;

namespace ProjectAdvergame.Module.PlayerCharacter
{
    public class PlayerCharacterConnector : BaseConnector
    {
        private PlayerCharacterController _playerCharacter;

        protected override void Connect()
        {
            Subscribe<MovePlayerCharacterMessage>(_playerCharacter.OnMove);
        }

        protected override void Disconnect()
        {
            Unsubscribe<MovePlayerCharacterMessage>(_playerCharacter.OnMove);
        }
    }
}