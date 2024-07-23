using Agate.MVC.Base;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ProjectAdvergame.Module.Quit
{
    public class QuitView : BaseView
    {
        [SerializeField] GameObject quitPanel;
        [SerializeField] Button closeButton;

        public void SetCallback(UnityAction onClose)
        {
            closeButton.onClick.RemoveAllListeners();
            closeButton.onClick.AddListener(onClose);
        }

        public void Show()
        {
            quitPanel.SetActive(true);
        }

        public void Hide()
        {
            quitPanel.SetActive(false);
        }
    }
}