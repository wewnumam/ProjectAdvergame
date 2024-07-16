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
        public TMP_Text scoreText;

        protected override void InitRenderModel(IScoreModel model)
        {
        }

        protected override void UpdateRenderModel(IScoreModel model)
        {
            if (model != null)
                accuracies = model.Accuracies;

            scoreText.SetText(model.CurrentScore.ToString());
        }
    }
}