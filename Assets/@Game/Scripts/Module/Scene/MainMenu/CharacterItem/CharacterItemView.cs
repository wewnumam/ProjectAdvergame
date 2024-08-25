using Agate.MVC.Base;
using NaughtyAttributes;
using ProjectAdvergame.Module.CharacterData;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ProjectAdvergame.Module.CharacterItem
{
    public class CharacterItemView : ObjectView<ICharacterItemModel>
    {
        [ReadOnly] public SO_CharacterData characterData;

        public TMP_Text fullName;
        public TMP_Text cost;
        public TMP_Text starProgress;
        public Button chooseButton;
        public Button unlockButton;
        public Slider unlockSlider;

        private UnityAction<int> onSubstractHeart;

        public void SetCallback(UnityAction onChooseLevel, UnityAction onUnlockLevel, UnityAction<int> onSubstractHeart)
        {
            chooseButton.onClick.RemoveAllListeners();
            chooseButton.onClick.AddListener(onChooseLevel);
            unlockButton.onClick.RemoveAllListeners();
            unlockButton.onClick.AddListener(onUnlockLevel);

            this.onSubstractHeart = onSubstractHeart;
        }

        protected override void InitRenderModel(ICharacterItemModel model)
        {
        }

        protected override void UpdateRenderModel(ICharacterItemModel model)
        {
            unlockButton.interactable = model.CurrentHeartCount >= characterData.cost;
        }

        internal void SubstractHeart(int cost)
        {
            onSubstractHeart?.Invoke(cost);
            Debug.Log(cost);
        }
    }
}