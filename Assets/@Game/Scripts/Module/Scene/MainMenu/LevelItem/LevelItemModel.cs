using Agate.MVC.Base;

namespace ProjectAdvergame.Module.LevelItem
{
    public class LevelItemModel : BaseModel, ILevelItemModel
    {
        public int CurrentHeartCount { get; private set; }

        public void SetCurrentHeartCount(int count)
        {
            CurrentHeartCount = count;
            SetDataAsDirty();
        }

        internal void SubtractHeart(int cost)
        {
            CurrentHeartCount -= cost;
            SetDataAsDirty();
        }
    }
}