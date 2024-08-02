using Agate.MVC.Base;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ProjectAdvergame.Module.CheatFeature
{
    public class CheatFeatureView : BaseView
    {
        public int heartAmount = 10;
        [SerializeField] Button addHeartButton;
        [SerializeField] Button fullStarButton;
        [SerializeField] Button resetDataButton;

        public void SetCallbacks(UnityAction onAddHeart, UnityAction onFullStar, UnityAction onResetData)
        {
            addHeartButton?.onClick.RemoveAllListeners();
            addHeartButton?.onClick.AddListener(onAddHeart);

            fullStarButton?.onClick.RemoveAllListeners();
            fullStarButton?.onClick.AddListener(onFullStar);
            
            resetDataButton?.onClick.RemoveAllListeners();
            resetDataButton?.onClick.AddListener(onResetData);
        }
    }
}