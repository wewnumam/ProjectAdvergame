using Agate.MVC.Base;
using NaughtyAttributes;
using ProjectAdvergame.Module.LevelData;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ProjectAdvergame.Module.LevelItem
{
    public class LevelItemView : ObjectView<ILevelItemModel>
    {
        [ReadOnly] public LevelData.LevelItem levelItem;
        [ReadOnly] public SO_LevelData levelData;

        public TMP_Text title;
        public TMP_Text cost;
        public Button chooseButton;
        public Button unlockButton;

        private UnityAction<int> onSubstractHeart;

        public void SetCallback(UnityAction onChooseLevel, UnityAction onUnlockLevel, UnityAction<int> onSubstractHeart)
        {
            chooseButton.onClick.RemoveAllListeners();
            chooseButton.onClick.AddListener(onChooseLevel);
            unlockButton.onClick.RemoveAllListeners();
            unlockButton.onClick.AddListener(onUnlockLevel);

            this.onSubstractHeart = onSubstractHeart;
        }

        protected override void InitRenderModel(ILevelItemModel model)
        {
        }

        protected override void UpdateRenderModel(ILevelItemModel model)
        {
            unlockButton.interactable = model.CurrentHeartCount >= levelItem.cost;
        }

        internal void SubstractHeart(int cost)
        {
            onSubstractHeart?.Invoke(cost);
            Debug.Log(cost);
        }
    }
}