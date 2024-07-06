using Agate.MVC.Base;
using ProjectAdvergame.Message;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace ProjectAdvergame.Module.Input
{
    public class TapInputController : BaseController<TapInputController>
    {
        private InputActionManager _inputActionsManager = new InputActionManager();

        public override IEnumerator Initialize()
        {
            yield return base.Initialize();
            _inputActionsManager.UI.Enable();
            _inputActionsManager.UI.TapStart.performed += OnTapStart;
            _inputActionsManager.Character.Tap.performed += OnTap;
        }

        public void OnGameOver(GameOverMessage message)
        {
            _inputActionsManager.Character.Disable();
        }

        private void OnTapStart(InputAction.CallbackContext context)
        {
            bool isOverUI = EventSystem.current.IsPointerOverGameObject();
            if (context.performed && !isOverUI)
            {
                _inputActionsManager.Character.Enable();
                _inputActionsManager.UI.Disable();
                Publish<StartPlayMessage>(new StartPlayMessage());
            }
        }

        private void OnTap(InputAction.CallbackContext context)
        {
            bool isOverUI = EventSystem.current.IsPointerOverGameObject();
            if (context.performed && !isOverUI)
            {
                Publish<TapInputMessageMessage>(new TapInputMessageMessage());
            }
        }
    }
}
