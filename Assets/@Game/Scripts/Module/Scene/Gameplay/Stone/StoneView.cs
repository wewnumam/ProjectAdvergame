using Agate.MVC.Base;
using ProjectAdvergame.Utility;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ProjectAdvergame.Module.Stone
{
    public class StoneView : BaseView
    {
        public Transform stoneObject;
        public float interval;
        public bool isMove;

        public UnityAction onFinished;

        public void SetCallback(UnityAction onFinished)
        {
            this.onFinished = onFinished;
        }

        public void SetStoneObjectPosition(StoneView previousStone, EnumManager.Direction direction)
        {
            float offset = direction == EnumManager.Direction.FromEast ? -interval : interval;
            stoneObject.position = previousStone.stoneObject.position + new Vector3(offset, 0, 1);
            isMove = true;
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

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(TagManager.TAG_PLAYER))
                foreach (var item in stoneObject.GetComponentsInChildren<Transform>())
                    item.gameObject.SetActive(false);
        }
    }
}