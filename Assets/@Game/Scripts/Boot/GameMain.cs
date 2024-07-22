using Agate.MVC.Base;
using Agate.MVC.Core;
using ProjectAdvergame.Module.GameConstants;
using ProjectAdvergame.Module.GameState;
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
                new GameStateConnector(),
            };
        }

        protected override IController[] GetDependencies()
        {
            return new IController[] {
                new LevelDataController(),
                new GameConstantsController(),
                new GameStateController(),
            };
        }

        protected override IEnumerator StartInit()
        {
            Application.targetFrameRate = -1;
            yield return null;
        }
    }
}
