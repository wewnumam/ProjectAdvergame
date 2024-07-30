using Agate.MVC.Base;
using NaughtyAttributes;
using ProjectAdvergame.Module.LevelData;
using ProjectAdvergame.Module.LevelItem;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ProjectAdvergame.Module.LevelSelection
{
    public class LevelSelectionView : ObjectView<ILevelSelectionModel>
    {
        [ReadOnly] public SO_LevelCollection levelCollection;
        [ReadOnly] public List<LevelItemView> listedLevel;
        public Transform container;
        public GameObject template;
        public TMP_Text currentLevelText;

        protected override void InitRenderModel(ILevelSelectionModel model)
        {
        }

        protected override void UpdateRenderModel(ILevelSelectionModel model)
        {
            currentLevelText.SetText($"{model.CurrentLevelTitle} ({model.CurrentLevelStar})");
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