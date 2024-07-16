using Agate.MVC.Base;
using Agate.MVC.Core;
using ProjectAdvergame.Module.GameConstants;
using ProjectAdvergame.Module.LevelData;
using System.Collections;
using UnityEngine;

namespace ProjectAdvergame.Boot
{
    public class GameMain : BaseMain<GameMain>, IMain
    {
        protected override IConnector[] GetConnectors()
        {
            return new IConnector[] {
                new LevelDataConnector(),
            };
        }

        protected override IController[] GetDependencies()
        {
            return new IController[] {
                new LevelDataController(),
                new GameConstantsController(),
            };
        }

        protected override IEnumerator StartInit()
        {
            Application.targetFrameRate = 60;
            yield return null;
        }
    }
}
