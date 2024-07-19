using Agate.MVC.Base;
using ProjectAdvergame.Message;

namespace ProjectAdvergame.Module.GameOver
{
    public class GameOverController : ObjectController<GameOverController, GameOverView>
    {
        internal void OnGameOver(GameOverMessage message)
        {
            Publish(new GameStateMessage(Utility.EnumManager.GameState.GameOver));
        }
    }
}