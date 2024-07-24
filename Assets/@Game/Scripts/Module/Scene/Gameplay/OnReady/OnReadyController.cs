using Agate.MVC.Base;
using ProjectAdvergame.Message;
using System;
using UnityEngine;

namespace ProjectAdvergame.Module.OnReady
{
    public class OnReadyController : ObjectController<OnReadyController, OnReadyView>
    {
        public void SetOnReadyCountdown(float countdown)
        {
            _view.readyOn = countdown;
        }

        internal void OnReady(OnReadyMessage message)
        {
            _view.Ready(message.OnComplete);
        }
    }
}