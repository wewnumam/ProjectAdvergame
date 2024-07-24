using Agate.MVC.Base;
using ProjectAdvergame.Message;

namespace ProjectAdvergame.Module.PlayerCharacter
{
    public class PlayerCharacterConnector : BaseConnector
    {
        private PlayerCharacterController _playerCharacter;

        protected override void Connect()
        {
            Subscribe<OnReadyMessage>(_playerCharacter.OnReady);
            Subscribe<MovePlayerCharacterMessage>(_playerCharacter.OnMove);
            Subscribe<BeatAccuracyMessage>(_playerCharacter.SetReaction);
        }

        protected override void Disconnect()
        {
            Unsubscribe<OnReadyMessage>(_playerCharacter.OnReady);
            Unsubscribe<MovePlayerCharacterMessage>(_playerCharacter.OnMove);
            Unsubscribe<BeatAccuracyMessage>(_playerCharacter.SetReaction);
        }
    }
}