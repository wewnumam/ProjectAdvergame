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

        private UnityAction<EnumManager.Direction> onFinished;

        private void Start()
        {
            transform.DOMove(new Vector3(0, 0, index), duration).SetEase(Ease.Linear).OnComplete(() => onFinished?.Invoke(direction));
        }

        public void SetCallback(UnityAction<EnumManager.Direction> onFinished)
        {
            this.onFinished = onFinished;
        }
    }
}