using Agate.MVC.Base;
using NaughtyAttributes;
using ProjectAdvergame.Utility;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ProjectAdvergame.Module.Score
{
    public class ScoreView : ObjectView<IScoreModel>
    {
        [ReadOnly] public List<EnumManager.BeatAccuracy> accuracies;
        public List<TMP_Text> scoreTexts;
        public List<TMP_Text> scorePointTexts;

        public Color transparentScoreColor;
        public Color initialScoreColor;
        public Color addScoreColor;
        public Color subtractScoreColor;

        protected override void InitRenderModel(IScoreModel model)
        {
        }

        protected override void UpdateRenderModel(IScoreModel model)
        {
            if (model != null)
                accuracies = model.Accuracies;

            foreach (var scoreText in scoreTexts)
                scoreText.SetText(model.CurrentScore.ToString());

            foreach (var scorePointText in scorePointTexts)
                scorePointText.SetText(model.CurrentScoreAmount.ToString());
        }
    }
}