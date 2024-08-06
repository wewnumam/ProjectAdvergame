using ProjectAdvergame.Utility;

namespace ProjectAdvergame.Message
{
    public struct GameResultScoreMessage
    {
        public int Score { get; }

        public GameResultScoreMessage(int score)
        {
            Score = score;
        }
    }
}