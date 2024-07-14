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
        }

        protected override void Disconnect()
        {
            Unsubscribe<StartPlayMessage>(_musicPlayer.StartPlay);
        }
    }
}