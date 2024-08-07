using ProjectAdvergame.Utility;

namespace ProjectAdvergame.Message
{
    public struct GameSettingVibrateMessage
    {
        public bool Vibrate { get; }

        public GameSettingVibrateMessage(bool vibrate)
        {
            Vibrate = vibrate;
        }
    }
}