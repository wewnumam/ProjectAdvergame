using ProjectAdvergame.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class SaveData
{
    public string CurrentUsername = TagManager.DEFAULT_USERNAME;
    public string CurrentCharacterName = TagManager.DEFAULT_CHARACTERNAME;
    public string CurrentLevelName = TagManager.DEFAULT_LEVELNAME;
    public int CurrentHeartCount;
    public List<string> UnlockedCharacters = new List<string>() { TagManager.DEFAULT_CHARACTERNAME };
    public List<StarRecords> UnlockedLevels = new List<StarRecords>() { new StarRecords(TagManager.DEFAULT_LEVELNAME, 0, 0) };
    public List<PlayingHistory> PlayingHistories = new List<PlayingHistory>() { new PlayingHistory(TagManager.DEFAULT_LEVELNAME, 0, DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()) };

    public StarRecords GetStarRecordsByLevelName(string levelName)
    {
        return UnlockedLevels.FirstOrDefault(r => r.LevelName == levelName);
    }

    public int GetTotalStarCount()
    {
        return UnlockedLevels.Sum(record => record.StarCount);
    }

    public int GetTotalXP()
    {
        return PlayingHistories.Sum(history => history.Score);
    }
}

[System.Serializable]
public class StarRecords
{
    public string LevelName;
    public int StarCount;
    public int HighScore;

    public StarRecords(string levelName, int starCount, int highScore)
    {
        LevelName = levelName;
        StarCount = starCount;
        HighScore = highScore;
    }
}

[System.Serializable]
public class PlayingHistory
{
    public string LevelName;
    public int Score;
    public long CreatedAt;

    public PlayingHistory(string levelName, int score, long createdAt)
    {
        this.LevelName = levelName;
        this.Score = score;
        this.CreatedAt = createdAt;
    }
}
