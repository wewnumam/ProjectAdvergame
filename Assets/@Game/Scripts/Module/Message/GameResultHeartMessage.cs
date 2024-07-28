using ProjectAdvergame.Utility;

namespace ProjectAdvergame.Message
{
    public struct GameResultHeartMessage
    {
        public int HeartAmount { get; }

        public GameResultHeartMessage(int heartAmount)
        {
            HeartAmount = heartAmount;
        }
    }
}