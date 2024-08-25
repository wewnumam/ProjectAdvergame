using Agate.MVC.Base;
using NaughtyAttributes;
using ProjectAdvergame.Module.CharacterItem;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using ProjectAdvergame.Module.CharacterData;
using ProjectAdvergame.Utility;

namespace ProjectAdvergame.Module.CharacterSelection
{
    public class CharacterSelectionView : ObjectView<ICharacterSelectionModel>
    {
        [ReadOnly] public SO_CharacterCollection characterCollection;
        [ReadOnly] public List<CharacterItemView> listedCharacter;
        public Transform previewParent;
        public Transform container;
        public GameObject template;
        public TMP_Text currentCharacterText;
        public TMP_Text progressText;
        public GameObject progressPanel;

        protected override void InitRenderModel(ICharacterSelectionModel model)
        {
        }

        protected override void UpdateRenderModel(ICharacterSelectionModel model)
        {
            currentCharacterText.SetText(model.CurrentCharacterFullName);

            if (previewParent.childCount > 0)
                Destroy(previewParent.GetChild(0).gameObject);

            if (model.CurrentPrefab != null)
            {
                GameObject obj = Instantiate(model.CurrentPrefab, previewParent);
                if (obj.TryGetComponent<Animator>(out var animator))
                    animator.Play(TagManager.ANIM_POSE[Random.Range(0, TagManager.ANIM_POSE.Length)]);
            }
        }

        internal void SubstractLevelItemHeart(int cost)
        {
            foreach (var item in listedCharacter)
            {
                item.SubstractHeart(cost);
            }
        }
    }
}