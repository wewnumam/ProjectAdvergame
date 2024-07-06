using Agate.MVC.Base;
using DG.Tweening;
using ProjectAdvergame.Message;
using System;
using UnityEngine;

namespace ProjectAdvergame.Module.BeatAccuracyEvaluator
{
    public class BeatAccuracyEvaluatorController : ObjectController<BeatAccuracyEvaluatorController, BeatAccuracyEvaluatorView>
    {
        public override void SetView(BeatAccuracyEvaluatorView view)
        {
            base.SetView(view);
            view.SetCallback(OnTapLate);
        }

        private void MovePlayerCharacter()
        {
            _view.tapIndex++;
            Publish<MovePlayerCharacterMessage>(new MovePlayerCharacterMessage());
        }

        private void OnTapLate()
        {
            MovePlayerCharacter();
            SetText("LATE");
        }

        internal void OnTap(TapInputMessageMessage message)
        {
            MovePlayerCharacter();

            if (_view.IsPhaseEarly())
            {
                SetText("EARLY");
            }
            else if (_view.IsPhasePerfect())
            {
                SetText("PERFECT");
            }
        }

        private void SetText(string text)
        {
            _view.accuracyText.SetText(text);
            _view.accuracyText.transform.localScale = Vector3.zero;
            _view.accuracyText.transform.DOScale(Vector3.one, .25f);
        }
    }
}