using Agate.MVC.Base;
using Agate.MVC.Core;
using NaughtyAttributes;
using ProjectAdvergame.Module.LevelData;
using ProjectAdvergame.Module.LevelItem;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace ProjectAdvergame.Module.LevelSelection
{
    public class LevelSelectionView : ObjectView<ILevelSelectionModel>
    {
        [ReadOnly] public SO_LevelCollection levelCollection;
        [ReadOnly] public List<LevelItemView> listedLevel;
        public Transform container;
        public GameObject template;

        protected override void InitRenderModel(ILevelSelectionModel model)
        {
        }

        protected override void UpdateRenderModel(ILevelSelectionModel model)
        {
        }

        internal void SubstractLevelItemHeart(int cost)
        {
            foreach (var item in listedLevel)
            {
                item.SubstractHeart(cost);
            }
        }
    }
}