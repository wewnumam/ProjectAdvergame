using ProjectAdvergame.Utility;

namespace ProjectAdvergame.Message
{
    public struct GameResultStarMessage
    {
        public int StarAmount { get; }

        public GameResultStarMessage(int starAmount)
        {
            StarAmount = starAmount;
        }
    }
}