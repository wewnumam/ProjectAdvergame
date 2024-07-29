using Agate.MVC.Base;
using ProjectAdvergame.Module.LevelData;
using System;
using System.Collections.Generic;

namespace ProjectAdvergame.Module.LevelSelection
{
    public class LevelSelectionModel : BaseModel, ILevelSelectionModel
    {
        public SO_LevelCollection LevelCollection { get; private set; }
        public List<StarRecords> UnlockedLevels { get; private set; }
        public int CurrentHeartCount { get; private set; }

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

        public void UpdateRender()
        {
            SetDataAsDirty();
        }

        internal void SubtractHeart(int cost)
        {
            CurrentHeartCount -= cost;
            SetDataAsDirty();
        }
    }
}