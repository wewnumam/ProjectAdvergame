using Agate.MVC.Base;
using ProjectAdvergame.Message;
using UnityEngine;

namespace ProjectAdvergame.Module.Score
{
    public class ScoreController : ObjectController<ScoreController, ScoreModel, IScoreModel, ScoreView>
    {
        public void SetScoreEarlyAmount(int amount) => _model.SetScoreEarlyAmount(amount);
        public void SetScorePerfectAmount(int amount) => _model.SetScorePerfectAmount(amount);
        public void SetScoreLateAmount(int amount) => _model.SetScoreLateAmount(amount);

        internal void AddScore(BeatAccuracyMessage message)
        {
            _model.AddScore(message.BeatAccuracy);
            _model.AddAccuracies(message.BeatAccuracy);
        }
    }
}