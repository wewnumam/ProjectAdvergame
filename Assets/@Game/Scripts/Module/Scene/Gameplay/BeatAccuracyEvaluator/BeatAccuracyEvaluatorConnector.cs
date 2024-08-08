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
            Subscribe<StartPlayMessage>(_beatAccuracyEvaluator.OnStartPlay);
            Subscribe<GameOverMessage>(_beatAccuracyEvaluator.OnGameOver);
            Subscribe<GameSettingVibrateMessage>(_beatAccuracyEvaluator.OnVibrate);
        }

        protected override void Disconnect()
        {
            Unsubscribe<TapInputMessageMessage>(_beatAccuracyEvaluator.OnTap);
            Unsubscribe<StartPlayMessage>(_beatAccuracyEvaluator.OnStartPlay);
            Unsubscribe<GameOverMessage>(_beatAccuracyEvaluator.OnGameOver);
            Unsubscribe<GameSettingVibrateMessage>(_beatAccuracyEvaluator.OnVibrate);
        }
    }
}