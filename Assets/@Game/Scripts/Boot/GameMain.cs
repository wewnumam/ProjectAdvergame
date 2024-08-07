using Agate.MVC.Base;
using Agate.MVC.Core;
using ProjectAdvergame.Module.GameConstants;
using ProjectAdvergame.Module.GameSettings;
using ProjectAdvergame.Module.GameState;
using ProjectAdvergame.Module.LevelData;
using ProjectAdvergame.Module.SaveSystem;
using System.Collections;
using UnityEngine;

namespace ProjectAdvergame.Boot
{
    public class GameMain : BaseMain<GameMain>, IMain
    {
        protected override IConnector[] GetConnectors()
        {
            return new IConnector[] {
                new SaveSystemConnector(),
                new LevelDataConnector(),
                new GameStateConnector(),
                new GameSettingsConnector(),
            };
        }

        protected override IController[] GetDependencies()
        {
            return new IController[] {
                new SaveSystemController(),
                new LevelDataController(),
                new GameConstantsController(),
                new GameStateController(),
                new GameSettingsController(),
            };
        }

        protected override IEnumerator StartInit()
        {
            Application.targetFrameRate = -1;
            yield return null;
        }
    }
}
