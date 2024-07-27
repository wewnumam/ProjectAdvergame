using Agate.MVC.Base;
using NaughtyAttributes;
using ProjectAdvergame.Module.LevelData;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ProjectAdvergame.Module.LevelItem
{
    public class LevelItemView : BaseView
    {
        [ReadOnly] public SO_LevelData levelData;

        public TMP_Text title;
        public TMP_Text cost;
        public Button chooseButton;

        public void SetCallback(UnityAction onChooseLevel)
        {
            chooseButton.onClick.RemoveAllListeners();
            chooseButton.onClick.AddListener(onChooseLevel);
        }
    }
}