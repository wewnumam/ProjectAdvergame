using Agate.MVC.Base;

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
    }
}