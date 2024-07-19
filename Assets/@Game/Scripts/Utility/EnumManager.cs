namespace ProjectAdvergame.Utility
{
    public class EnumManager
    {
        public enum BeatAccuracy
        {
            Early,
            Perfect,
            Late
        }

        public enum Direction
        {
            FromEast,
            FromWest,
            FromNorth
        }

        public enum GameState
        {
            PreGame,
            Playing,
            Pause,
            GameOver,
            GameWin
        }

        public enum StoneType
        {
            Normal,
            AddHealth
        }
    }
}