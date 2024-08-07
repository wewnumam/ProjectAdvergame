using ProjectAdvergame.Utility;

namespace ProjectAdvergame.Message
{
    public struct GameSettingVolumeMessage
    {
        public float Volume { get; }

        public GameSettingVolumeMessage(float volume)
        {
            Volume = volume;
        }
    }
}