using Agate.MVC.Base;

namespace ProjectAdvergame.Module.CharacterItem
{
    public class CharacterItemModel : BaseModel, ICharacterItemModel
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