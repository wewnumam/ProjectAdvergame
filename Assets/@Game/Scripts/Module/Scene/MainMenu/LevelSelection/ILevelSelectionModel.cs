using Agate.MVC.Base;
using ProjectAdvergame.Module.LevelData;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectAdvergame.Module.LevelSelection
{
    public interface ILevelSelectionModel : IBaseModel
    {
        List<SO_LevelData> LevelCollection { get; }
        List<StarRecords> UnlockedLevels {  get; }
        int CurrentHeartCount { get; }
        int CurrentStarCount { get; }
        string CurrentLevelTitle { get; }
        int CurrentLevelStar { get; }
        Sprite CurrentArtwork { get;  }
        Color CurrentBackgroundColor { get; }
        AudioClip CurrentClip { get; }
        Material CurrentSkybox { get; }
    }
}