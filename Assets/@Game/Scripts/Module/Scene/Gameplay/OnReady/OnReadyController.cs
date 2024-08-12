using Agate.MVC.Base;
using ProjectAdvergame.Message;
using System;
using UnityEngine;

namespace ProjectAdvergame.Module.OnReady
{
    public class OnReadyController : ObjectController<OnReadyController, OnReadyView>
    {
        private int _levelHighscore;

        public void SetLevelHighscore(int levelHighscore) => _levelHighscore = levelHighscore;
 
        public override void SetView(OnReadyView view)
        {
            base.SetView(view);
            view.onReadyPanel.gameObject.SetActive(true);
            view.levelHighscore.SetText(_levelHighscore.ToString());
            view.tweener.ShowList();
        }

        public void SetOnReadyCountdown(float countdown)
        {
            _view.readyOn = countdown;
        }


        internal void OnReady(OnReadyMessage message)
        {
            _view.Ready(message.OnComplete);
            _view.tweener.onComplete += () => _view.onReadyPanel.SetActive(false);
            _view.tweener.ShowList();
        }
    }
}