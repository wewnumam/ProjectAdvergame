using Agate.MVC.Base;
using ProjectAdvergame.Utility;

namespace ProjectAdvergame.Module.GameSettings
{
    public interface IGameSettingsModel : IBaseModel
    {
        float AudioVolume { get; }
        bool IsVibrateOn { get; }
    }
}