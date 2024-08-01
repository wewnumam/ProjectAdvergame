using Agate.MVC.Base;
using ProjectAdvergame.Module.LevelData;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectAdvergame.Module.LevelSelection
{
    public class LevelSelectionModel : BaseModel, ILevelSelectionModel
    {
        public SO_LevelCollection LevelCollection { get; private set; }
        public List<StarRecords> UnlockedLevels { get; private set; }
        public int CurrentHeartCount { get; private set; }
        public string CurrentLevelTitle { get; private set; }
        public int CurrentLevelStar { get; private set; }
        public Sprite CurrentArtwork { get; private set; }
        public Color CurrentBackgroundColor { get; private set; }

        public void SetLevelCollection(SO_LevelCollection levelCollection)
        {
            LevelCollection = levelCollection;
            SetDataAsDirty();
        }

        public void SetUnlockedLevel(List<StarRecords> unlockedLevels)
        {
            UnlockedLevels = unlockedLevels;
            SetDataAsDirty();
        }

        public void SetCurrentHeartCount(int count)
        {
            CurrentHeartCount = count;
            SetDataAsDirty();
        }

        public void SubtractHeart(int cost)
        {
            CurrentHeartCount -= cost;
            SetDataAsDirty();
        }

        public void SetCurrentContent(string title, int star, Sprite artwork, Color backgroundColor)
        {
            CurrentLevelTitle = title;
            CurrentLevelStar = star;
            CurrentArtwork = artwork;
            CurrentBackgroundColor = backgroundColor;
            SetDataAsDirty();
        }
    }
}