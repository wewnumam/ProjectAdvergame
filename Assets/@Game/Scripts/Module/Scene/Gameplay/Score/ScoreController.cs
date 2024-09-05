using Agate.MVC.Base;
using DG.Tweening;
using ProjectAdvergame.Message;
using ProjectAdvergame.Module.LevelData;
using ProjectAdvergame.Utility;
using System;
using System.Collections.Generic;
using UnityEngine;
using static ProjectAdvergame.Utility.EnumManager;

namespace ProjectAdvergame.Module.Score
{
    public class ScoreController : ObjectController<ScoreController, ScoreModel, IScoreModel, ScoreView>
    {
        private List<Beat> _beats;

        public void SetBeatCollections(List<Beat> beats) => _beats = beats;

        public void SetScoreEarlyAmount(int amount) => _model.SetScoreEarlyAmount(amount);
        public void SetScorePerfectAmount(int amount) => _model.SetScorePerfectAmount(amount);
        public void SetScoreLateAmount(int amount) => _model.SetScoreLateAmount(amount);

        internal void AddScore(BeatAccuracyMessage message)
        {
            foreach (var text in _view.scoreTexts)
            {
                if (message.BeatAccuracy == EnumManager.BeatAccuracy.Perfect)
                    text.color = _view.addScoreColor;
                else
                    text.color = _view.subtractScoreColor;
                text.DOColor(_view.initialScoreColor, 1f);
            }

            foreach (var text in _view.scorePointTexts)
            {
                if (message.BeatAccuracy == EnumManager.BeatAccuracy.Perfect)
                    text.color = _view.addScoreColor;
                else
                    text.color = _view.subtractScoreColor;
                text.DOColor(_view.transparentScoreColor, 1f);
            }

            _model.AddScore(message.BeatAccuracy);
            _model.AddAccuracies(message.BeatAccuracy);
        }

        internal void OnGameWin(GameWinMessage message)
        {
            Publish(new GameResultStarMessage(_model.StarCalculator(_beats.Count)));
            Publish(new GameResultScoreMessage(_model.CurrentScore));
        }
    }
}