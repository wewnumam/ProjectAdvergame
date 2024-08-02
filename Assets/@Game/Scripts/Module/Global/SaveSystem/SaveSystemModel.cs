using Agate.MVC.Base;
using ProjectAdvergame.Utility;
using System;
using Tayx.Graphy.Utils.NumString;

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

        public void SetStarRecord(int starAmount)
        {
            StarRecords previousStarRecord = SaveData.GetStarRecordsByLevelName(SaveData.CurrentLevelName);
            int starCount = starAmount < previousStarRecord.StarCount ? previousStarRecord.StarCount : starAmount;

            SaveData.GetStarRecordsByLevelName(SaveData.CurrentLevelName).StarCount = starCount;
            SetDataAsDirty();
        }

        public void AddStarRecord(string LevelName)
        {
            StarRecords starRecords = new StarRecords(LevelName, 0);
            SaveData.UnlockedLevels.Add(starRecords);
            SetDataAsDirty();
        }

        public void FullStar()
        {
            SaveData.UnlockedLevels.ForEach(level => level.StarCount = 5);
            SetDataAsDirty();
        }

    }
}