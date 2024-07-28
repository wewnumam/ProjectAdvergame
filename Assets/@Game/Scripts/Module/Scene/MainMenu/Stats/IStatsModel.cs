using Agate.MVC.Base;
using ProjectAdvergame.Module.LevelData;

namespace ProjectAdvergame.Module.Stats
{
    public interface IStatsModel : IBaseModel
    {
        int CurrentHeart { get; }
        int CurrentStar { get; }
    }
}