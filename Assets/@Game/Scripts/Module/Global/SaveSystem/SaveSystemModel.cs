using Agate.MVC.Base;
using System;

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

        public void SetCurrentCharacterName(string characterName)
        {
            SaveData.CurrentCharacterName = characterName;
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

        internal bool IsNewStar(int star)
        {
            return star > SaveData.GetStarRecordsByLevelName(SaveData.CurrentLevelName).StarCount;
        }

        public void SetStarRecord(int starAmount)
        {
            SaveData.GetStarRecordsByLevelName(SaveData.CurrentLevelName).StarCount = starAmount;
            SetDataAsDirty();
        }

        public void AddHistory(int score)
        {
            PlayingHistory playingHistory = new PlayingHistory(SaveData.CurrentLevelName, score, DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());
            SaveData.PlayingHistories.Add(playingHistory);
        }

        internal bool IsNewHighScore(int score)
        {
            return score > SaveData.GetStarRecordsByLevelName(SaveData.CurrentLevelName).HighScore;
        }

        internal void SetHighscore(int score)
        {
            SaveData.GetStarRecordsByLevelName(SaveData.CurrentLevelName).HighScore = score;
            SetDataAsDirty();
        }

        public void AddStarRecord(string LevelName)
        {
            StarRecords starRecords = new StarRecords(LevelName, 0, 0);
            SaveData.UnlockedLevels.Add(starRecords);
            SetDataAsDirty();
        }

        public void FullStar()
        {
            SaveData.UnlockedLevels.ForEach(level => level.StarCount = 5);
            SetDataAsDirty();
        }

        public void AddUnlockedCharacter(string characterName)
        {
            SaveData.UnlockedCharacters.Add(characterName);
            SetDataAsDirty();
        }

        internal void SetCurrentUsername(string username)
        {
            SaveData.CurrentUsername = username;
            SetDataAsDirty();
        }
    }
}