using Agate.MVC.Base;

namespace ProjectAdvergame.Module.LevelData
{
    public interface ILevelDataModel : IBaseModel
    {
        SO_LevelData CurrentLevelData { get; }
        SO_LevelCollection LevelCollection { get; }
    }
}