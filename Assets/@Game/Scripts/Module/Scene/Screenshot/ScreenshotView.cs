using Agate.MVC.Base;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using UnityEngine;

namespace ProjectAdvergame.Scene.Screenshot
{
    public class ScreenshotView : BaseSceneView
    {
        [Header("Buttons")]
        public Button backButton;
        public Button urlButton;
        
        [Header("Username")]
        public TMP_InputField usernameInput;
        public TMP_Text usernameText;

        [Header("Rank")]
        public TMP_Text rankText;

        [Header("Badge")]
        public Slider badgeSlider;
        public TMP_Text currentBadgeText;
        public TMP_Text nextBadgeText;
        public TMP_Text badgeScoreText;
        
        [Header("Level")]
        public TMP_Text starText;
        public TMP_Text unlockedSongText;
        public TMP_Dropdown favoriteSongs;

        public UnityEvent onStart;
        public UnityEvent onEnd;

        private UnityAction<string> onShare;

        public void Share(string target)
        {
            onShare?.Invoke(target);
        }

        public void SetCallback(UnityAction onBack, UnityAction onUrl, UnityAction<string> onShare, UnityAction<string> onEditUsername)
        {
            this.onShare = onShare;

            usernameInput.onEndEdit.AddListener(onEditUsername);

            urlButton.onClick.RemoveAllListeners();
            urlButton.onClick.AddListener(onUrl);
            
            backButton.onClick.RemoveAllListeners();
            backButton.onClick.AddListener(onBack);
        }
    }
}
