using Agate.MVC.Base;
using ProjectAdvergame.Module.LevelData;

namespace ProjectAdvergame.Module.LevelSelection
{
    public interface ILevelSelectionModel : IBaseModel
    {
        SO_LevelCollection LevelCollection { get; }
    }
}