using Agate.MVC.Base;
using ProjectAdvergame.Message;

namespace ProjectAdvergame.Module.BeatAccuracyEvaluator
{
    public class BeatAccuracyEvaluatorConnector : BaseConnector
    {
        private BeatAccuracyEvaluatorController _beatAccuracyEvaluator;

        protected override void Connect()
        {
            Subscribe<TapInputMessageMessage>(_beatAccuracyEvaluator.OnTap);
        }

        protected override void Disconnect()
        {
            Unsubscribe<TapInputMessageMessage>(_beatAccuracyEvaluator.OnTap);
        }
    }
}