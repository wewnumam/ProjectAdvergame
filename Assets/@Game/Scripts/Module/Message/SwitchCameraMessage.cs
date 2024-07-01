using ProjectAdvergame.Utility;

namespace ProjectAdvergame.Message
{
    public struct SwitchCameraMessage 
    {
        public EnumManager.Direction Direction { get; }

        public SwitchCameraMessage(EnumManager.Direction direction)
        {
            Direction = direction;
        }
    }
}