using Agate.MVC.Base;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

namespace ProjectAdvergame.Scene.Screenshot
{
    public class ScreenshotView : BaseSceneView
    {
        public Button backButton;
        public Button urlButton;
        public TMP_Text rankText;
        public TMP_Text currentBadgeText;
        public TMP_Text nextBadgeText;
        public TMP_Text badgeScoreText;
        public TMP_Text starText;
        public TMP_Text unlockedSongText;

        public UnityEvent onStart;
        public UnityEvent onEnd;

        private UnityAction<string> onShare;

        public void Share(string target)
        {
            onShare?.Invoke(target);
        }

        public void SetButtonCallback(UnityAction onBack, UnityAction onUrl, UnityAction<string> onShare)
        {
            this.onShare = onShare;

            urlButton.onClick.RemoveAllListeners();
            urlButton.onClick.AddListener(onUrl);
            
            backButton.onClick.RemoveAllListeners();
            backButton.onClick.AddListener(onBack);
        }
    }
}
