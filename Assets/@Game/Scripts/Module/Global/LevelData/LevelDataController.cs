using Agate.MVC.Base;
using System.Collections;
using UnityEngine;

namespace ProjectAdvergame.Module.LevelData
{
    public class LevelDataController : DataController<LevelDataController, LevelDataModel, ILevelDataModel>
    {
        public override IEnumerator Initialize()
        {
            SO_LevelData levelData = Resources.Load<SO_LevelData>(@"LevelData/LevelData_0");
            _model.SetCurrentLevelData(levelData);

            return base.Initialize();
        }
    }
}
