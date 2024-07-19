using Agate.MVC.Base;
using DG.Tweening;
using ProjectAdvergame.Message;
using ProjectAdvergame.Module.GameState;
using ProjectAdvergame.Utility;
using System;
using UnityEngine;

namespace ProjectAdvergame.Module.GamePause
{
    public class GamePauseController : BaseController<GamePauseController>
    {
        private GameStateController _gameState;

        internal void OnPause(GamePauseMessage message)
        {
            if (_gameState.IsStatePlaying())
            {
                Publish(new GameStateMessage(EnumManager.GameState.Pause));
                Time.timeScale = 0;
            } 
            else if (_gameState.IsStatePause())
            {
                Publish(new GameStateMessage(EnumManager.GameState.Playing));
                Time.timeScale = 1;
            }
        }
    }
}