using Agate.MVC.Base;
using ProjectAdvergame.Utility;
using System.Collections.Generic;

namespace ProjectAdvergame.Module.Score
{
    public interface IScoreModel : IBaseModel
    {
        int CurrentScore { get; }
        int CurrentScoreAmount { get; }

        List<EnumManager.BeatAccuracy> Accuracies { get; }
    }
}