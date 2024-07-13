using Agate.MVC.Base;
using ProjectAdvergame.Message;
using System;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace ProjectAdvergame.Module.Input
{
    public class TapInputController : BaseController<TapInputController>
    {
        private InputActionManager _inputActionsManager = new InputActionManager();
        private bool _isPlaying;

        public override IEnumerator Initialize()
        {
            yield return base.Initialize();
            _inputActionsManager.UI.Enable();
            _inputActionsManager.UI.TapStart.performed += OnTapStart;
            _inputActionsManager.UI.Pause.performed += OnPause;
            _inputActionsManager.Character.Tap.performed += OnTap;
        }

        private void OnPause(InputAction.CallbackContext context)
        {
            Publish<GamePauseMessage>(new GamePauseMessage());
        }

        public void OnGameOver(GameOverMessage message)
        {
            _inputActionsManager.Character.Disable();
        }

        private void OnTapStart(InputAction.CallbackContext context)
        {
            bool isOverUI = EventSystem.current.IsPointerOverGameObject();
            if (context.performed && !isOverUI && !_isPlaying)
            {
                _inputActionsManager.Character.Enable();
                Publish<StartPlayMessage>(new StartPlayMessage());
                _isPlaying = true;
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
