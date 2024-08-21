using Agate.MVC.Base;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using ProjectAdvergame.Utility;
using NaughtyAttributes;

namespace ProjectAdvergame.Module.Stone
{
    public class StoneView : BaseView
    {
        [ReadOnly] public float duration;
        [ReadOnly] public int index;
        [ReadOnly] public float zIndex;
        [ReadOnly] public EnumManager.Direction direction;
        [ReadOnly] public EnumManager.StoneType stoneType;
        [ReadOnly] public StoneView previousStone;
        [ReadOnly] public bool isSwitchCamera;

        public UnityAction onComplete;
        public UnityAction<StoneView> stoneFallEvent;
        private UnityAction<EnumManager.Direction> switchCameraEvent;

        public void SetCallback(UnityAction onComplete)
        {
            this.onComplete = onComplete;
        }

        public void Play()
        {   
            transform.DOMove(new Vector3(0, 0, zIndex + index), duration).SetEase(Ease.Linear).OnComplete(() => {
                switchCameraEvent?.Invoke(direction);
                previousStone?.Fall();
                onComplete?.Invoke();
            });
        }

        public void Fall()
        {
            transform.DOMoveY(-10, 3).OnComplete(() => gameObject.SetActive(false));
        }

        public void Pause()
        {
            transform.DOTogglePause();
        }

        public void SwitchCamera(UnityAction<EnumManager.Direction> switchCameraEvent)
        {
            this.switchCameraEvent = switchCameraEvent;
        }
    }
}