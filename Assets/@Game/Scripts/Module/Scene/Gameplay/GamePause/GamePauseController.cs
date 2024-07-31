using Agate.MVC.Base;
using DG.Tweening;
using ProjectAdvergame.Boot;
using ProjectAdvergame.Message;
using ProjectAdvergame.Module.GameState;
using ProjectAdvergame.Utility;
using System;
using UnityEngine;

namespace ProjectAdvergame.Module.GamePause
{
    public class GamePauseController : ObjectController<GamePauseController, GamePauseView>
    {
        private GameStateController _gameState;

        public override void SetView(GamePauseView view)
        {
            base.SetView(view);
            view.SetCallbacks(TogglePause, OnMainMenu);
        }

        private void TogglePause()
        {
            Publish(new GamePauseMessage());
        }

        private void OnMainMenu()
        {
            Time.timeScale = 1;
            SceneLoader.Instance.LoadScene(TagManager.SCENE_MAINMENU);
        }

        internal void OnPause(GamePauseMessage message)
        {
            if (_gameState.IsStatePlaying())
            {
                Publish(new GameStateMessage(EnumManager.GameState.Pause));
                Time.timeScale = 0;
                _view.pausePanel.SetActive(true);
                _view.pauseIconImage.sprite = _view.resumeSprite;
            } 
            else if (_gameState.IsStatePause())
            {
                Publish(new GameStateMessage(EnumManager.GameState.Playing));
                Time.timeScale = 1;
                _view.pausePanel.SetActive(false);
                _view.pauseIconImage.sprite = _view.resumeSprite;
            }
        }

        internal void OnGameOver(GameOverMessage message)
        {
            _view.pauseButton.gameObject.SetActive(false);
        }

        internal void OnGameWin(GameWinMessage message)
        {
            _view.pauseButton.gameObject.SetActive(false);
        }
    }
}