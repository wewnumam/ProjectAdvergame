using ProjectAdvergame.Boot;
using Agate.MVC.Base;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace ProjectAdvergame.Scene.MainMenu
{
    public class MainMenuView : BaseSceneView
    {
        [SerializeField]
        private Button _button;

        public void SetButtonCallback(UnityAction callback)
        {
            _button.onClick.RemoveAllListeners();
            _button.onClick.AddListener(callback);
        }
    }
}
