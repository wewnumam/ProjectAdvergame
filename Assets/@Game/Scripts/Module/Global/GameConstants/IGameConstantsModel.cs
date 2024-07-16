using Agate.MVC.Base;

namespace ProjectAdvergame.Module.GameConstants
{
    public interface IGameConstantsModel : IBaseModel
    {
        SO_GameConstants GameConstants { get; }
    }
}