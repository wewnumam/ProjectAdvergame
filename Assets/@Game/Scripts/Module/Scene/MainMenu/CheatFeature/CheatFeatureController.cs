using Agate.MVC.Base;
using ProjectAdvergame.Boot;
using ProjectAdvergame.Message;
using ProjectAdvergame.Module.Input;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectAdvergame.Module.CheatFeature
{
    public class CheatFeatureController : ObjectController<CheatFeatureController, CheatFeatureView>
    {
        public override void SetView(CheatFeatureView view)
        {
            base.SetView(view);
            view.SetCallbacks(OnAddHeart, OnFullStar, OnResetData);
        }

        private void OnResetData()
        {
            Publish(new DeleteSaveDataMessage());
            SceneLoader.Instance.RestartScene();
        }

        private void OnFullStar()
        {
            Publish(new FullStarMessage());
            SceneLoader.Instance.RestartScene();
        }

        private void OnAddHeart()
        {
            Publish(new GameResultHeartMessage(_view.heartAmount));
            SceneLoader.Instance.RestartScene();
        }
    }
}