using Agate.MVC.Base;
using ProjectAdvergame.Message;

namespace ProjectAdvergame.Module.BeatAccuracyEvaluator
{
    public class BeatAccuracyEvaluatorConnector : BaseConnector
    {
        private BeatAccuracyEvaluatorController _beatAccuracyEvaluator;

        protected override void Connect()
        {
            Subscribe<TapInputMessage>(_beatAccuracyEvaluator.OnTap);
            Subscribe<TapStartedInputMessage>(_beatAccuracyEvaluator.OnTapStarted);
            Subscribe<TapEndedInputMessage>(_beatAccuracyEvaluator.OnTapEnded);
            Subscribe<StartPlayMessage>(_beatAccuracyEvaluator.OnStartPlay);
            Subscribe<GameOverMessage>(_beatAccuracyEvaluator.OnGameOver);
            Subscribe<GameSettingVibrateMessage>(_beatAccuracyEvaluator.OnVibrate);
        }

        protected override void Disconnect()
        {
            Unsubscribe<TapInputMessage>(_beatAccuracyEvaluator.OnTap);
            Unsubscribe<TapStartedInputMessage>(_beatAccuracyEvaluator.OnTapStarted);
            Unsubscribe<TapEndedInputMessage>(_beatAccuracyEvaluator.OnTapEnded);
            Unsubscribe<StartPlayMessage>(_beatAccuracyEvaluator.OnStartPlay);
            Unsubscribe<GameOverMessage>(_beatAccuracyEvaluator.OnGameOver);
            Unsubscribe<GameSettingVibrateMessage>(_beatAccuracyEvaluator.OnVibrate);
        }
    }
}