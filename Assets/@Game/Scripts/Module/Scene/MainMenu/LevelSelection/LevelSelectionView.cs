using Agate.MVC.Base;
using NaughtyAttributes;
using ProjectAdvergame.Module.LevelData;
using ProjectAdvergame.Module.LevelItem;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectAdvergame.Module.LevelSelection
{
    public class LevelSelectionView : ObjectView<ILevelSelectionModel>
    {
        [ReadOnly] public SO_LevelCollection levelCollection;
        [ReadOnly] public List<LevelItemView> listedLevel;
        public Transform container;
        public GameObject template;
        public TMP_Text currentLevelText;
        public List<Image> starImages;
        public Image artworkImage;
        public Image backgroundImage;
        public AudioSource audioSource;

        protected override void InitRenderModel(ILevelSelectionModel model)
        {
        }

        protected override void UpdateRenderModel(ILevelSelectionModel model)
        {
            currentLevelText.SetText(model.CurrentLevelTitle);
            artworkImage.sprite = model.CurrentArtwork;
            backgroundImage.color = model.CurrentBackgroundColor;
            if (audioSource.clip != model.CurrentClip)
            { 
                audioSource.clip = model.CurrentClip;
                audioSource.Play();
            }

            for (int i = 0; i < starImages.Count; i++)
                    starImages[i].enabled = i < model.CurrentLevelStar;
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