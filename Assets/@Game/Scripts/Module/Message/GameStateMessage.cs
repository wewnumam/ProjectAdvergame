using ProjectAdvergame.Utility;

namespace ProjectAdvergame.Message
{
    public struct GameStateMessage 
    {
        public EnumManager.GameState GameState { get; }

        public GameStateMessage(EnumManager.GameState gameState) 
        { 
            GameState = gameState;
        }
    }
}