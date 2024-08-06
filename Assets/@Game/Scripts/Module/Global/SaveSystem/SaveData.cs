using ProjectAdvergame.Utility;
using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class SaveData
{
    public string CurrentLevelName = TagManager.DEFAULT_LEVELNAME;
    public int CurrentHeartCount;
    public List<StarRecords> UnlockedLevels = new List<StarRecords>() { new StarRecords(TagManager.DEFAULT_LEVELNAME, 0, 0) };

    public StarRecords GetStarRecordsByLevelName(string levelName)
    {
        return UnlockedLevels.FirstOrDefault(r => r.LevelName == levelName);
    }

    public int GetTotalStarCount()
    {
        return UnlockedLevels.Sum(record => record.StarCount);
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
