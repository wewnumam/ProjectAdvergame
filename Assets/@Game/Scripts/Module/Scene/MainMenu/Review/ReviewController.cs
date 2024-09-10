using Agate.MVC.Base;
using ProjectAdvergame.Boot;
using ProjectAdvergame.Utility;
using UnityEngine;

namespace ProjectAdvergame.Module.Review
{
    public class ReviewController : ObjectController<ReviewController, ReviewView>
    {
        public override void SetView(ReviewView view)
        {
            base.SetView(view);
            view.SetCallbacks(OnReview, Done);

            if (PlayerPrefs.HasKey(TagManager.KEY_REVIEW))
                view.reviewPanel.SetActive(PlayerPrefs.GetInt(TagManager.KEY_REVIEW) <= 0);
            else
                PlayerPrefs.SetInt(TagManager.KEY_REVIEW, 0);

        }

        private void OnReview() 
        {
            Application.OpenURL(_view.link);
            Done();
        }

        private void Done() => PlayerPrefs.SetInt(TagManager.KEY_REVIEW, 1);
    }
}