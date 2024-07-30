using Agate.MVC.Base;
using ProjectAdvergame.Module.LevelData;
using System.Collections.Generic;

namespace ProjectAdvergame.Module.LevelSelection
{
    public interface ILevelSelectionModel : IBaseModel
    {
        SO_LevelCollection LevelCollection { get; }
        List<StarRecords> UnlockedLevels {  get; }
        int CurrentHeartCount { get; }
        string CurrentLevelTitle { get; }
        int CurrentLevelStar { get; }
    }
}