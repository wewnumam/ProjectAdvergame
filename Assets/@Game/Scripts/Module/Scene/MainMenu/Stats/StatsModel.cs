using Agate.MVC.Base;
using System;

namespace ProjectAdvergame.Module.Stats
{
    public class StatsModel : BaseModel, IStatsModel
    {
        public int CurrentHeart { get; private set; }

        public int CurrentStar { get; private set; }

        public void SetCurrentHeart(int heart)
        {
            CurrentHeart = heart;
            SetDataAsDirty();
        }

        public void SetCurrentStar(int star)
        {
            CurrentStar = star;
            SetDataAsDirty();
        }

        public void UpdateRender() => SetDataAsDirty();

        public void SubtractHeart(int amount)
        {
            CurrentHeart -= amount;
            SetDataAsDirty();
        }
    }
}