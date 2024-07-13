using Agate.MVC.Base;
using DG.Tweening;
using ProjectAdvergame.Message;
using ProjectAdvergame.Utility;
using System;
using UnityEngine;

namespace ProjectAdvergame.Module.GamePause
{
    public class GamePauseController : BaseController<GamePauseController>
    {
        private bool _isPlaying = false;

        internal void OnPause(GamePauseMessage message)
        {
            Time.timeScale = _isPlaying ? 0 : 1;
            _isPlaying = !_isPlaying;
        }
    }
}