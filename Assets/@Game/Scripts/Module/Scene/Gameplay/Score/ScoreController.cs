using Agate.MVC.Base;
using ProjectAdvergame.Message;
using UnityEngine;

namespace ProjectAdvergame.Module.Score
{
    public class ScoreController : ObjectController<ScoreController, ScoreModel, IScoreModel, ScoreView>
    {
        internal void AddScore(BeatAccuracyMessage message)
        {
            Debug.Log(message.BeatAccuracy);
            _model.AddAccuracies(message.BeatAccuracy);
        }
    }
}