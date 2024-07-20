using Agate.MVC.Base;
using DG.Tweening;
using ProjectAdvergame.Message;
using ProjectAdvergame.Utility;
using ProjectAdvergame.Module.LevelData;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ProjectAdvergame.Module.BeatAccuracyEvaluator
{
    public class BeatAccuracyEvaluatorController : ObjectController<BeatAccuracyEvaluatorController, BeatAccuracyEvaluatorView>
    {
        private float _minPerfectTapPhase;
        private List<BeatCollection> _beatCollections;

        #region Public Function

        public void SetMinPerfectTapPhase(float minPerfectTapPhase)
        {
            _minPerfectTapPhase = minPerfectTapPhase;
        }

        public void SetBeatCollections(List<BeatCollection> beatCollections)
        {
            _beatCollections = beatCollections;
        }

        #endregion

        private void MovePlayerCharacter()
        {
            _view.tapIndex++;
            Publish(new MovePlayerCharacterMessage());

            if (_view.isPlaying)
                if (_view.HasNextBeat())
                    if (_view.IsCurrentBeatAddHealth())
                        OnBeatAddHealth();
        }

        private void SetText(string text)
        {
            _view.accuracyText.SetText(text);
        }

        public override void SetView(BeatAccuracyEvaluatorView view)
        {
            base.SetView(view);
            view.SetCallback(OnTapLate, OnBeatCollectionEnd);
            view.beatCollections = _beatCollections;
            view.minPerfectTapPhase = _minPerfectTapPhase;
        }

        #region Callback Listener

        private void OnTapLate()
        {
            MovePlayerCharacter();
            SetText("LATE");
            Publish(new BeatAccuracyMessage(EnumManager.BeatAccuracy.Late));
        }
        

        private void OnBeatCollectionEnd()
        {
            Publish(new SwitchCameraMessage(EnumManager.Direction.FromNorth));
        }

        private void OnBeatAddHealth()
        {
            Publish(new AddHealthMessage());
        }

        #endregion

        #region Connector Listener

        internal void OnStartPlay(StartPlayMessage message)
        {
            _view.isPlaying = true;
        }

        internal void OnTap(TapInputMessageMessage message)
        {
            if (_view.IsPhaseEarly())
            {
                SetText("EARLY");
                Publish(new BeatAccuracyMessage(EnumManager.BeatAccuracy.Early));
            }
            else if (_view.IsPhasePerfect())
            {
                MovePlayerCharacter();
                SetText("PERFECT");
                Publish(new BeatAccuracyMessage(EnumManager.BeatAccuracy.Perfect));
            }
        }

        internal void OnGameOver(GameOverMessage message)
        {
            _view.isPlaying = false;
        }

        #endregion
    }
}