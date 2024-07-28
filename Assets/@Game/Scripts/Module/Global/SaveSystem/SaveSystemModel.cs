using Agate.MVC.Base;
using ProjectAdvergame.Utility;

namespace ProjectAdvergame.Module.SaveSystem
{
    public class SaveSystemModel : BaseModel, ISaveSystemModel
    {
        public SaveData SaveData { get; private set; }

        public void SetSaveData(SaveData saveData)
        {
            SaveData = saveData;
            SetDataAsDirty();
        }

        public void SetCurrentLevelName(string levelName)
        {
            SaveData.CurrentLevelName = levelName;
            SetDataAsDirty();
        }

        public void AddHeart(int amount)
        {
            SaveData.CurrentHeartCount += amount;
            SetDataAsDirty();
        }

        public void SubtractHeart(int amount)
        {
            SaveData.CurrentHeartCount -= amount;
            SetDataAsDirty();
        }

        public void AddStar(int amount)
        {
            SaveData.CurrentStarCount += amount;
            SetDataAsDirty();
        }

        public void SubtractStar(int amount)
        {
            SaveData.CurrentStarCount -= amount;
            SetDataAsDirty();
        }
    }
}