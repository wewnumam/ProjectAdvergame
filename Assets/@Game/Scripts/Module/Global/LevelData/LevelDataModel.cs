using Agate.MVC.Base;

namespace ProjectAdvergame.Module.LevelData
{
    public class LevelDataModel : BaseModel, ILevelDataModel
    {
        public SO_LevelData CurrentLevelData { get; private set; }

        public void SetCurrentLevelData(SO_LevelData levelData)
        {
            CurrentLevelData = levelData;
            SetDataAsDirty();
        }
    }
}