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
            Subscribe<MovePlayerCharacterEarlyMessage>(_playerCharacter.OnMoveEarly);
            Subscribe<CurrentZPositionMessage>(_playerCharacter.SetZPosition);
            Subscribe<BeatAccuracyMessage>(_playerCharacter.SetReaction);
            Subscribe<GameOverMessage>(_playerCharacter.OnGameOver);
            Subscribe<GameWinMessage>(_playerCharacter.OnGameWin);
        }

        protected override void Disconnect()
        {
            Unsubscribe<OnReadyMessage>(_playerCharacter.OnReady);
            Unsubscribe<MovePlayerCharacterMessage>(_playerCharacter.OnMove);
            Unsubscribe<MovePlayerCharacterEarlyMessage>(_playerCharacter.OnMoveEarly);
            Unsubscribe<CurrentZPositionMessage>(_playerCharacter.SetZPosition);
            Unsubscribe<BeatAccuracyMessage>(_playerCharacter.SetReaction);
            Unsubscribe<GameOverMessage>(_playerCharacter.OnGameOver);
            Unsubscribe<GameWinMessage>(_playerCharacter.OnGameWin);
        }
    }
}