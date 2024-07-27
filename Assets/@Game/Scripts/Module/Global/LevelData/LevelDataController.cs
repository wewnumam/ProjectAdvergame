using Agate.MVC.Base;
using ProjectAdvergame.Message;
using ProjectAdvergame.Module.SaveSystem;
using System;
using System.Collections;
using UnityEngine;

namespace ProjectAdvergame.Module.LevelData
{
    public class LevelDataController : DataController<LevelDataController, LevelDataModel, ILevelDataModel>
    {
        private SaveSystemController _saveSystemController;

        public override IEnumerator Initialize()
        {
            SO_LevelCollection levelCollection = Resources.Load<SO_LevelCollection>(@"LevelCollection");
            _model.SetLevelCollection(levelCollection);

            yield return base.Initialize();
        }

        public void SetCurrentLevel(string levelName)
        {
            SO_LevelData levelData = Resources.Load<SO_LevelData>(@"LevelData/" + levelName);
            _model.SetCurrentLevelData(levelData);
        }

        internal void OnChooseLevel(ChooseLevelMessage message)
        {
            Debug.Log($"CHOOSE LEVEL: {message.LevelName}");
            SetCurrentLevel(message.LevelName);
            _saveSystemController.SetCurrentLevelName(message.LevelName);
        }
    }
}
