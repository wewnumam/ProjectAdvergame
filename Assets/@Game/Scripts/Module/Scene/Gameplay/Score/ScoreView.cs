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

        protected override void InitRenderModel(IScoreModel model)
        {
        }

        protected override void UpdateRenderModel(IScoreModel model)
        {
            if (model != null)
                accuracies = model.Accuracies;

            foreach (var scoreText in scoreTexts)
                scoreText.SetText(model.CurrentScore.ToString());
        }
    }
}