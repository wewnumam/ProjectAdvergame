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

        protected override void InitRenderModel(IScoreModel model)
        {
        }

        protected override void UpdateRenderModel(IScoreModel model)
        {
            if (model != null)
                accuracies = model.Accuracies;
        }
    }
}