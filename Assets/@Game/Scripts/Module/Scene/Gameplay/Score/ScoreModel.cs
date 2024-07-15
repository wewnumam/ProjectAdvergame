using Agate.MVC.Base;
using ProjectAdvergame.Utility;
using System.Collections.Generic;

namespace ProjectAdvergame.Module.Score
{
    public class ScoreModel : BaseModel, IScoreModel
    {
        public int CurrentScore { get; private set; }

        public List<EnumManager.BeatAccuracy> Accuracies { get; private set; }

        public void SetCurrentScore(int score)
        {
            CurrentScore = score;
        }

        public void AddAccuracies(EnumManager.BeatAccuracy beatAccuracy)
        {
            if (Accuracies == null)
                Accuracies = new List<EnumManager.BeatAccuracy>();

            Accuracies.Add(beatAccuracy);
            SetDataAsDirty();
        }
    }
}