using Agate.MVC.Base;
using ProjectAdvergame.Message;
using System;
using System.Collections;
using UnityEngine;

namespace ProjectAdvergame.Module.LevelData
{
    public class LevelDataController : DataController<LevelDataController, LevelDataModel, ILevelDataModel>
    {
        public void SetCurrentLevel(string levelName)
        {
            SO_LevelData levelData = Resources.Load<SO_LevelData>(@"LevelData/" + levelName);
            _model.SetCurrentLevelData(levelData);
        }
    }
}
