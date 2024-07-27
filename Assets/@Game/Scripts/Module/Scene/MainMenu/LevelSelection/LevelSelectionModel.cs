using Agate.MVC.Base;
using ProjectAdvergame.Module.LevelData;

namespace ProjectAdvergame.Module.LevelSelection
{
    public class LevelSelectionModel : BaseModel, ILevelSelectionModel
    {
        public SO_LevelCollection LevelCollection { get; private set; }

        public void SetLevelCollection(SO_LevelCollection levelCollection)
        {
            LevelCollection = levelCollection;
            SetDataAsDirty();
        }

        public void UpdateRender()
        {
            SetDataAsDirty();
        }
    }
}