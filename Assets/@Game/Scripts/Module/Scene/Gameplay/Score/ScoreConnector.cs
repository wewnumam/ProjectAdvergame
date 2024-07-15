using Agate.MVC.Base;
using ProjectAdvergame.Message;

namespace ProjectAdvergame.Module.Score
{
    public class ScoreConnector : BaseConnector
    {
        private ScoreController _score;

        protected override void Connect()
        {
            Subscribe<BeatAccuracyMessage>(_score.AddScore);
        }

        protected override void Disconnect()
        {
            Unsubscribe<BeatAccuracyMessage>(_score.AddScore);
        }
    }
}