using Agate.MVC.Base;
using ProjectAdvergame.Message;

namespace ProjectAdvergame.Module.GameSettings
{
    public class GameSettingsController : DataController<GameSettingsController, GameSettingsModel, IGameSettingsModel>
    {
        internal void OnVolume(GameSettingVolumeMessage message)
        {
            _model.SetVolume(message.Volume);
        }

        internal void OnVibrate(GameSettingVibrateMessage message)
        {
            _model.SetVibrate(message.Vibrate);
        }
    }
}
