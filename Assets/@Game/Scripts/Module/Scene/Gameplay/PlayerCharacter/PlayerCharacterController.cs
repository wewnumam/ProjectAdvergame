using Agate.MVC.Base;
using DG.Tweening;
using ProjectAdvergame.Message;
using ProjectAdvergame.Utility;
using UnityEngine;

namespace ProjectAdvergame.Module.PlayerCharacter
{
    public class PlayerCharacterController : ObjectController<PlayerCharacterController, PlayerCharacterView>
    {
        private bool isFly;

        public override void SetView(PlayerCharacterView view)
        {
            base.SetView(view);
            _view.animator.Play(TagManager.ANIM_POSE[Random.Range(0, 2)]);
        }

        internal void OnMove(MovePlayerCharacterMessage message)
        {
            _view.transform.DOMoveZ(_view.transform.position.z + message.MoveAmount, message.MoveAmount * .1f);
        }

        internal void OnMoveEarly(MovePlayerCharacterEarlyMessage message)
        {
            isFly = true;
            _view.animator.Play(TagManager.ANIM_FLY);
            _view.transform.DOJump(new Vector3(0, 0, _view.transform.position.z + message.MoveAmount), 5, 1, message.Duration - .1f).OnComplete(() =>
            {
                isFly = false;
                _view.animator.Play(TagManager.ANIM_IDLE);
            });
        }

        internal void OnReady(OnReadyMessage message)
        {
            _view.animator.Play(TagManager.ANIM_IDLE);
            _view.playerCharacterObject.DORotate(Vector3.zero, 1);
        }

        internal void SetReaction(BeatAccuracyMessage message)
        {
            _view.reactionImage.transform.localScale = Vector3.zero;
            
            if (message.BeatAccuracy == Utility.EnumManager.BeatAccuracy.Early)
            {
                _view.animator.Play(TagManager.ANIM_STOP[Random.Range(0, 2)]);
                _view.reactionImage.sprite = _view.earlyReaction;
            }
            else if (message.BeatAccuracy == Utility.EnumManager.BeatAccuracy.Perfect)
            {
                if (!isFly)
                    _view.animator.Play(TagManager.ANIM_STEP[Random.Range(0, 2)]);
                _view.reactionImage.sprite = _view.perfectReactions[Random.Range(0, _view.perfectReactions.Count)];
            }
            else if (message.BeatAccuracy == Utility.EnumManager.BeatAccuracy.Late)
            {
                _view.animator.Play(TagManager.ANIM_FALL);
                _view.reactionImage.sprite = _view.lateReaction;
            }

            _view.reactionImage.transform.DOScale(Vector3.one, 1f).SetEase(Ease.OutExpo);
        }

        internal void OnGameOver(GameOverMessage message)
        {
            _view.animator.Play(TagManager.ANIM_LOSE);
            _view.transform.DOMoveY(-50, 10);
            _view.reactionImage.sprite = _view.lateReaction;
        }

        internal void OnGameWin(GameWinMessage message)
        {
            OnMove(new MovePlayerCharacterMessage(1));
            _view.animator.Play(TagManager.ANIM_WIN);
            _view.playerCharacterObject.DORotate(new Vector3(0, 180, 0), 1);
            _view.reactionImage.gameObject.SetActive(false);
        }
    }
}