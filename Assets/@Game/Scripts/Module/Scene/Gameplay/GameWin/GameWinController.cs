using Agate.MVC.Base;
using DG.Tweening;
using ProjectAdvergame.Boot;
using ProjectAdvergame.Message;
using ProjectAdvergame.Utility;

namespace ProjectAdvergame.Module.GameWin
{
    public class GameWinController : ObjectController<GameWinController, GameWinView>
    {
        public override void SetView(GameWinView view)
        {
            base.SetView(view);
            view.SetCallbacks(OnMainMenu, OnReplay);
        }

        private void OnMainMenu()
        {
            SceneLoader.Instance.LoadScene(TagManager.SCENE_MAINMENU);
        }

        private void OnReplay()
        {
            SceneLoader.Instance.RestartScene();
        }

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
            for (int i = 0; i < message.StarAmount; i++)
            {
                _view.starImages[i].DOFade(1, 1).SetDelay(i);
            }
        }
    }
}