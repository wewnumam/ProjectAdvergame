using Agate.MVC.Base;
using ProjectAdvergame.Module.Stone;
using ProjectAdvergame.Utility;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ProjectAdvergame.Module.StoneManager
{
    public class StoneManagerView : BaseView
    {
        public List<StoneView> stones;
        public EnumManager.Direction direction;
        public GameObject nextStoneManager;

        private UnityAction onSwitchCamera;

        private void OnEnable()
        {
            for (int i = 0; i < stones.Count; i++)
            {
                if (i != 0)
                    stones[i].SetStoneObjectPosition(stones[i - 1], direction);
            }
        }
    }
}