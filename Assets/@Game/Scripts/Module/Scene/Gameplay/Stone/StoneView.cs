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
        [ReadOnly] public EnumManager.Direction direction;
        [ReadOnly] public EnumManager.StoneType stoneType;
        [ReadOnly] public StoneView previousStone;

        public UnityAction<StoneView> stoneFallEvent;
        private UnityAction<EnumManager.Direction> switchCameraEvent;

        public void Play()
        {   
            transform.DOMove(new Vector3(0, 0, index), duration).SetEase(Ease.Linear).OnComplete(() => {
                switchCameraEvent?.Invoke(direction);
                previousStone?.Fall();
            });
        }

        public void Fall()
        {
            transform.DOMoveY(-10, 3);
        }

        public void SwitchCamera(UnityAction<EnumManager.Direction> switchCameraEvent)
        {
            this.switchCameraEvent = switchCameraEvent;
        }
    }
}