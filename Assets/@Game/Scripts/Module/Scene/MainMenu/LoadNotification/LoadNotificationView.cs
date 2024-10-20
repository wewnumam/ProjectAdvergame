using Agate.MVC.Base;
using TMPro;
using UnityEngine;

namespace ProjectAdvergame.Module.LoadNotification
{
    public class LoadNotificationView : BaseView
    {
        public TMP_Text versionText;

        private void Awake()
        {
            versionText?.SetText($"v{Application.version}");
        }

        public void LinkTo(string url)
        {
            Application.OpenURL(url);
        }

        public void QuitApp()
        {
            Application.Quit();
        }
    }
}