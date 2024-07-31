using Agate.MVC.Base;
using ProjectAdvergame.Message;
using System;
using UnityEngine;

namespace ProjectAdvergame.Module.OnReady
{
    public class OnReadyController : ObjectController<OnReadyController, OnReadyView>
    {
        public override void SetView(OnReadyView view)
        {
            base.SetView(view);
            view.countdownText.gameObject.SetActive(false);
            view.onReadyPanel.gameObject.SetActive(true);
            view.tapText.gameObject.SetActive(true);
        }

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