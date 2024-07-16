using Agate.MVC.Base;
using DG.Tweening;
using ProjectAdvergame.Message;
using ProjectAdvergame.Utility;
using ProjectAdvergame.Module.LevelData;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectAdvergame.Module.BeatAccuracyEvaluator
{
    public class BeatAccuracyEvaluatorController : ObjectController<BeatAccuracyEvaluatorController, BeatAccuracyEvaluatorView>
    {
        private float _minPerfectTapPhase;
        private List<BeatCollection> _beatCollections;

        public void SetMinPerfectTapPhase(float minPerfectTapPhase)
        {
            _minPerfectTapPhase = minPerfectTapPhase;
        }

        public void SetBeatCollections(List<BeatCollection> beatCollections)
        {
            _beatCollections = beatCollections;
        }

        public override void SetView(BeatAccuracyEvaluatorView view)
        {
            base.SetView(view);
            view.SetCallback(OnTapLate);
            view.beatCollections = _beatCollections;
            view.minPerfectTapPhase = _minPerfectTapPhase;
        }

        private void MovePlayerCharacter()
        {
            _view.tapIndex++;
            Publish(new MovePlayerCharacterMessage());
        }

        private void OnTapLate()
        {
            MovePlayerCharacter();
            SetText("LATE");
            Publish(new BeatAccuracyMessage(EnumManager.BeatAccuracy.Late));
        }

        internal void OnTap(TapInputMessageMessage message)
        {
            MovePlayerCharacter();

            if (_view.IsPhaseEarly())
            {
                SetText("EARLY");
                Publish(new BeatAccuracyMessage(EnumManager.BeatAccuracy.Early));
            }
            else if (_view.IsPhasePerfect())
            {
                SetText("PERFECT");
                Publish(new BeatAccuracyMessage(EnumManager.BeatAccuracy.Perfect));
            }
        }
        internal void OnStartPlay(StartPlayMessage message)
        {
            _view.isPlaying = true;
        }

        private void SetText(string text)
        {
            _view.accuracyText.SetText(text);
            _view.accuracyText.transform.localScale = Vector3.zero;
            _view.accuracyText.transform.DOScale(Vector3.one, .25f);
        }

    }
}