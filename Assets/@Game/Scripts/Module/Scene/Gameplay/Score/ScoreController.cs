using Agate.MVC.Base;
using ProjectAdvergame.Message;
using ProjectAdvergame.Module.LevelData;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectAdvergame.Module.Score
{
    public class ScoreController : ObjectController<ScoreController, ScoreModel, IScoreModel, ScoreView>
    {
        private List<BeatCollection> _beatCollections;

        public void SetBeatCollections(List<BeatCollection> beatCollections)
        {
            _beatCollections = beatCollections;
        }

        public void SetScoreEarlyAmount(int amount) => _model.SetScoreEarlyAmount(amount);
        public void SetScorePerfectAmount(int amount) => _model.SetScorePerfectAmount(amount);
        public void SetScoreLateAmount(int amount) => _model.SetScoreLateAmount(amount);

        internal void AddScore(BeatAccuracyMessage message)
        {
            _model.AddScore(message.BeatAccuracy);
            _model.AddAccuracies(message.BeatAccuracy);
        }

        internal void OnGameWin(GameWinMessage message)
        {
            int totalBeat = 0;
            foreach (var beatCollection in _beatCollections)
                totalBeat += beatCollection.beats.Count;
            

            Publish(new GameResultStarMessage(_model.StarCalculator(totalBeat)));
        }
    }
}