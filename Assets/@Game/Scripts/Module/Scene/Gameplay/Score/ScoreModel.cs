using Agate.MVC.Base;
using ProjectAdvergame.Utility;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectAdvergame.Module.Score
{
    public class ScoreModel : BaseModel, IScoreModel
    {
        public int CurrentScore { get; private set; }
        
        public int ScoreEarlyAmount { get; private set; }
        public int ScorePerfectAmount { get; private set; }
        public int ScoreLateAmount { get; private set; }
        
        public List<EnumManager.BeatAccuracy> Accuracies { get; private set; }

        public void SetScoreEarlyAmount(int amount) => ScoreEarlyAmount = amount;
        public void SetScorePerfectAmount(int amount) => ScorePerfectAmount = amount;
        public void SetScoreLateAmount(int amount) => ScoreLateAmount = amount;

        public void AddScore(EnumManager.BeatAccuracy beatAccuracy)
        {
            if (beatAccuracy == EnumManager.BeatAccuracy.Early)
                CurrentScore += ScoreEarlyAmount;
            else if (beatAccuracy == EnumManager.BeatAccuracy.Perfect)
                CurrentScore += ScorePerfectAmount;
            else if (beatAccuracy == EnumManager.BeatAccuracy.Late)
                CurrentScore += ScoreLateAmount;

            SetDataAsDirty();
        }

        public void AddAccuracies(EnumManager.BeatAccuracy beatAccuracy)
        {
            if (Accuracies == null)
                Accuracies = new List<EnumManager.BeatAccuracy>();

            Accuracies.Add(beatAccuracy);
            SetDataAsDirty();
        }

        public int StarCalculator(int totalBeat)
        {
            int perfectScore = 0;
            foreach (var accuracy in Accuracies)
            {
                if (accuracy == EnumManager.BeatAccuracy.Perfect)
                {
                    perfectScore += ScorePerfectAmount;
                }
            }

            float percentage = (float)perfectScore / (totalBeat * ScorePerfectAmount);
            int stars = (int)Mathf.Round(percentage * 5);

            return Mathf.Min(Mathf.Max(stars, 0), 5);
        }
    }
}