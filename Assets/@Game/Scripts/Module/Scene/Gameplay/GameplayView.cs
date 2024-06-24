using Agate.MVC.Base;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using ProjectAdvergame.Module.PlayerCharacter;
using ProjectAdvergame.Module.StoneManager;

namespace ProjectAdvergame.Scene.Gameplay
{
    public class GameplayView : BaseSceneView
    {
        public PlayerCharacterView PlayerCharacterView;
        public StoneManagerView StoneManagerView;

        [SerializeField]
        private Button _button;

        public void SetButtonCallback(UnityAction callback)
        {
            _button.onClick.RemoveAllListeners();
            _button.onClick.AddListener(callback);
        }
    }
}
