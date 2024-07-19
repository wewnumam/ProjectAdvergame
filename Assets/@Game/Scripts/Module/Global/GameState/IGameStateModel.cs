using Agate.MVC.Base;
using ProjectAdvergame.Utility;

namespace ProjectAdvergame.Module.GameState
{
    public interface IGameStateModel : IBaseModel
    {
        EnumManager.GameState GameState { get; }
    }
}