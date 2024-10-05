using Agate.MVC.Base;
using ProjectAdvergame.Module.LevelData;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectAdvergame.Module.LevelSelection
{
    public class LevelSelectionModel : BaseModel, ILevelSelectionModel
    {
        public List<SO_LevelData> LevelCollection { get; private set; }
        public List<StarRecords> UnlockedLevels { get; private set; }
        public int CurrentHeartCount { get; private set; }
        public int CurrentStarCount { get; private set; }
        public string CurrentLevelTitle { get; private set; }
        public int CurrentLevelStar { get; private set; }
        public Sprite CurrentArtwork { get; private set; }
        public Color CurrentBackgroundColor { get; private set; }
        public AudioClip CurrentClip { get; private set; }
        public Material CurrentSkybox { get; private set; }

        public void SetLevelCollection(List<SO_LevelData> levelCollection)
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

        public void SetCurrentStarCount(int count)
        {
            CurrentStarCount = count;
            SetDataAsDirty();
        }

        public void SubtractHeart(int cost)
        {
            CurrentHeartCount -= cost;
            SetDataAsDirty();
        }

        public void SetCurrentContent(SO_LevelData levelData, StarRecords starRecords, Sprite artwork, AudioClip musicClip, Material skybox)
        {
            CurrentLevelTitle = levelData.title;
            CurrentLevelStar = starRecords.StarCount;
            CurrentArtwork = artwork;
            CurrentBackgroundColor = levelData.backgroundColor;
            CurrentClip = musicClip;
            CurrentSkybox = skybox;
            SetDataAsDirty();
        }
    }
}