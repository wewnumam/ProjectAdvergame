using Agate.MVC.Base;

namespace ProjectAdvergame.Module.LevelData
{
    public class LevelDataModel : BaseModel, ILevelDataModel
    {
        public SO_LevelData CurrentLevelData { get; private set; }
        public SO_LevelCollection LevelCollection { get; private set; }

        public void SetCurrentLevelData(SO_LevelData levelData)
        {
            CurrentLevelData = levelData;
            SetDataAsDirty();
        }

        public void SetLevelCollection(SO_LevelCollection levelCollection)
        {
            LevelCollection = levelCollection;
            SetDataAsDirty();
        }
    }
}