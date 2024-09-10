using Agate.MVC.Base;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ProjectAdvergame.Module.Review
{
    public class ReviewView : BaseView
    {
        public string link;
        public GameObject reviewPanel;
        [SerializeField] Button reviewButton;
        [SerializeField] Button closeButton;

        public void SetCallbacks(UnityAction onReview, UnityAction onClose)
        {
            reviewButton.onClick.RemoveAllListeners();
            reviewButton.onClick.AddListener(onReview);
            closeButton.onClick.RemoveAllListeners();
            closeButton.onClick.AddListener(onClose);
        }
    }
}