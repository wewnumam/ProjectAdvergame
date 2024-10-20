using Agate.MVC.Base;
using DG.Tweening;
using ProjectAdvergame.Message;
using ProjectAdvergame.Utility;
using ProjectAdvergame.Module.LevelData;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.Mathematics;
using System.Collections;
using ProjectAdvergame.Boot;

namespace ProjectAdvergame.Module.BeatAccuracyEvaluator
{
    public class BeatAccuracyEvaluatorController : ObjectController<BeatAccuracyEvaluatorController, BeatAccuracyEvaluatorView>
    {
        private float _minPerfectTapPhase;
        private List<Beat> _beats;
        private bool _isVibrate;
        private List<float> zPosCollection;
        private bool isLongBeatState;

        #region Public Function

        public void SetMinPerfectTapPhase(float minPerfectTapPhase)
        {
            _minPerfectTapPhase = minPerfectTapPhase;
        }

        public void SetBeatCollections(List<Beat> beats)
        {
            _beats = beats;
        }

        public void SetVibrate(bool vibrate)
        {
            _isVibrate = vibrate;
        }

        #endregion

        private void MovePlayerCharacter()
        {
            _view.tapIndex++;
            _view.tapText?.SetText(_view.tapIndex.ToString());

            if (!_view.IsPhaseLate())
                Publish(new MovePlayerCharacterMessage(zPosCollection[_view.currentBeatIndex - 1]));
            
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
            view.SetCallback(OnTapLate, OnBeatLong, OnBeatCollectionEnd);
            view.beats = _beats;
            view.initialMinPerfectTapPhase = _minPerfectTapPhase;
            view.minPerfectTapPhase = _minPerfectTapPhase;
            view.accuracyText.SetText(string.Empty);
        }

        #region Callback Listener

        private void OnTapLate()
        {
            MovePlayerCharacter();
            SetText("LATE");
            Publish(new BeatAccuracyMessage(EnumManager.BeatAccuracy.Late, _view.IsCurrentBeatLong() ? EnumManager.StoneType.LongBeat : EnumManager.StoneType.Normal, _view.currentBeatIndex));
            
            if (_isVibrate && !_view.IsCurrentBeatLong())
                Handheld.Vibrate();
        }

        private void OnBeatLong()
        {
            float interval = _view.beats[_view.currentBeatIndex - 1].interval - _view.beats[_view.currentBeatIndex - 2].interval;
            Publish(new MovePlayerCharacterEarlyMessage(zPosCollection[_view.currentBeatIndex - 1], interval));
        }
        

        private void OnBeatCollectionEnd()
        {
            Publish(new SwitchCameraMessage(EnumManager.Direction.FromNorth));
            Publish(new GameStateMessage(EnumManager.GameState.GameWin));
            Publish(new GameWinMessage());
        }

        private void OnBeatAddHealth()
        {
            Publish(new AddHealthMessage());
        }

        private IEnumerator AddLongBeatScore()
        {
            while (isLongBeatState)
            {
                Publish(new OnLongBeatMessage());
                yield return new WaitForSecondsRealtime(_minPerfectTapPhase);
            }
        }

        #endregion

        #region Connector Listener

        internal void OnStartPlay(StartPlayMessage message)
        {
            _view.isPlaying = true;
        }

        internal void OnTap(TapInputMessage message)
        {
            if (_view.IsPhaseEarly() && !_view.IsCurrentBeatLong())
            {
                SetText("EARLY");
                Publish(new BeatAccuracyMessage(EnumManager.BeatAccuracy.Early, EnumManager.StoneType.Normal, _view.currentBeatIndex));

                if (_isVibrate)
                    Handheld.Vibrate();
            }
            else if (_view.IsPhasePerfect() && !_view.IsCurrentBeatLong())
            {
                MovePlayerCharacter();
                SetText("PERFECT");
                Publish(new BeatAccuracyMessage(EnumManager.BeatAccuracy.Perfect, EnumManager.StoneType.Normal, _view.currentBeatIndex));
            }
        }

        internal void OnTapStarted(TapStartedInputMessage message)
        {
            if (_view.IsCurrentBeatLong())
            {
                _view.particle.Play();
                isLongBeatState = true;
                GameMain.Instance.RunCoroutine(AddLongBeatScore());
            }
            else
            {
                _view.particle.Stop();
            }
        }

        internal void OnTapEnded(TapEndedInputMessage message)
        {
            if (_view.IsCurrentBeatLong())
            {
                _view.particle.Stop();
                isLongBeatState = false;
            }
        }

        internal void OnGameOver(GameOverMessage message)
        {
            _view.isPlaying = false;
        }

        internal void OnVibrate(GameSettingVibrateMessage message)
        {
            SetVibrate(message.Vibrate);
        }

        internal void UpdateZPosCollection(UpdateZPosCollectionMessage message)
        {
            zPosCollection = message.ZPosCollection;
        }

        #endregion
    }
}