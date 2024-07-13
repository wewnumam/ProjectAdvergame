using Agate.MVC.Base;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using ProjectAdvergame.Utility;

namespace ProjectAdvergame.Module.Stone
{
    public class StoneView : BaseView
    {
        public float duration;
        public int index;
        public EnumManager.Direction direction;
        public StoneView previousStone;

        public UnityAction<StoneView> stoneFallEvent;
        private UnityAction<EnumManager.Direction> switchCameraEvent;

        public void Play()
        {
            float positionX = 0;
            
            if (direction == EnumManager.Direction.FromEast)
                positionX = -.5f;
            else if (direction == EnumManager.Direction.FromWest)
                positionX = .5f;
            
            transform.DOMove(new Vector3(positionX, 0, index), duration).SetEase(Ease.Linear).OnComplete(() => {
                switchCameraEvent?.Invoke(direction);
                previousStone?.Fall();
                transform.DOMoveX(0, .5f);
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