using Agate.MVC.Base;
using ProjectAdvergame.Utility;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ProjectAdvergame.Module.Stone
{
    public class StoneView : BaseView
    {
        public Transform stoneObject;
        public float interval;
        public UnityEvent onFinished;
        public bool isMove;

        public void SetStoneObjectPosition(StoneView previousStone, EnumManager.Direction direction)
        {
            float offset = direction == EnumManager.Direction.LeftToRight ? -interval : interval;
            stoneObject.position = previousStone.stoneObject.position + new Vector3(offset, 0, 1);
            isMove = true;
        }

        public void FlipStoneX()
        {
            Vector3 vector3 = stoneObject.position;
            vector3.x *= -1;
            stoneObject.position = vector3;
        }

        private void Update()
        {
            if (!isMove) return;

            stoneObject.position = Vector3.MoveTowards(stoneObject.position, transform.position, Time.deltaTime);
            if (stoneObject.position == transform.position)
            {
                onFinished?.Invoke();
                isMove = false;
            }
        }
    }
}