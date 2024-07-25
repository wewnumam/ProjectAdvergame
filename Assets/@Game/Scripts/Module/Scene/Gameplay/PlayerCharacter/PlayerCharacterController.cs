using Agate.MVC.Base;
using DG.Tweening;
using ProjectAdvergame.Message;
using System;
using UnityEngine;

namespace ProjectAdvergame.Module.PlayerCharacter
{
    public class PlayerCharacterController : ObjectController<PlayerCharacterController, PlayerCharacterView>
    {
        internal void OnMove(MovePlayerCharacterMessage message)
        {
            _view.transform.DOMoveZ(_view.transform.position.z + 1, .1f).OnComplete(() => _view.transform.DOMoveZ(Mathf.Ceil(_view.transform.position.z), 0));
        }

        internal void OnReady(OnReadyMessage message)
        {
            _view.playerCharacterObject.DORotate(Vector3.zero, 1);
        }

        internal void SetReaction(BeatAccuracyMessage message)
        {
            _view.reactionImage.transform.localScale = Vector3.zero;
            
            if (message.BeatAccuracy == Utility.EnumManager.BeatAccuracy.Early)
                _view.reactionImage.sprite = _view.earlyReaction;
            else if (message.BeatAccuracy == Utility.EnumManager.BeatAccuracy.Perfect)
                _view.reactionImage.sprite = _view.perfectReaction;
            else if (message.BeatAccuracy == Utility.EnumManager.BeatAccuracy.Late)
                _view.reactionImage.sprite = _view.lateReaction;

            _view.reactionImage.transform.DOScale(Vector3.one, 1f).SetEase(Ease.OutExpo);
        }
    }
}