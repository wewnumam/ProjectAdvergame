using Agate.MVC.Base;
using ProjectAdvergame.Message;

namespace ProjectAdvergame.Module.GameWin
{
    public class GameWinController : ObjectController<GameWinController, GameWinView>
    {
        internal void OnGameWin(GameWinMessage message)
        {
            _view.gameWinPanel.SetActive(true);
        }

        internal void ShowHeartResult(GameResultHeartMessage message)
        {
            _view.heartResultText.SetText(message.HeartAmount.ToString());
        }

        internal void ShowStarResult(GameResultStarMessage message)
        {
            _view.starResultText.SetText(message.StarAmount.ToString());
        }
    }
}