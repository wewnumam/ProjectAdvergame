using Agate.MVC.Base;
using ProjectAdvergame.Message;

namespace ProjectAdvergame.Module.MusicPlayer
{
    public class MusicPlayerConnector : BaseConnector
    {
        private MusicPlayerController _musicPlayer;

        protected override void Connect()
        {
            Subscribe<StartPlayMessage>(_musicPlayer.StartPlay);
            Subscribe<GamePauseMessage>(_musicPlayer.OnPause);
            Subscribe<GameOverMessage>(_musicPlayer.OnGameOver);
        }

        protected override void Disconnect()
        {
            Unsubscribe<StartPlayMessage>(_musicPlayer.StartPlay);
            Unsubscribe<GamePauseMessage>(_musicPlayer.OnPause);
            Unsubscribe<GameOverMessage>(_musicPlayer.OnGameOver);
        }
    }
}