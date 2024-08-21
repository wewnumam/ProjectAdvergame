using Agate.MVC.Base;
using ProjectAdvergame.Message;
using ProjectAdvergame.Module.GameState;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectAdvergame.Module.Input
{
    public class TapInputController : BaseController<TapInputController>
    {
        private GameStateController _gameState;
        private InputActionManager _inputActionsManager = new InputActionManager();
        private int tapStartCounter;
        private float touchStartTime;

        public override IEnumerator Initialize()
        {
            yield return base.Initialize();
            _inputActionsManager.UI.Enable();
            _inputActionsManager.UI.TapStart.performed += OnTapStart;
            _inputActionsManager.UI.Pause.performed += OnPause;
            _inputActionsManager.Character.Tap.performed += OnTap;
            _inputActionsManager.Character.Tap.started += OnTapStarted;
            _inputActionsManager.Character.Tap.canceled += OnTapEnded;
        }

        public override IEnumerator Terminate()
        {
            _inputActionsManager.UI.TapStart.performed -= OnTapStart;
            _inputActionsManager.UI.Pause.performed -= OnPause;
            _inputActionsManager.Character.Tap.performed -= OnTap;
            _inputActionsManager.Character.Tap.started -= OnTapStarted;
            _inputActionsManager.Character.Tap.canceled -= OnTapEnded;

            _inputActionsManager.UI.Disable();
            _inputActionsManager.Character.Disable();

            yield return base.Terminate();
        }

        private void OnPause(InputAction.CallbackContext context)
        {
            Publish(new GamePauseMessage());
        }

        private void OnTapStart(InputAction.CallbackContext context)
        {
            if (context.performed && _gameState.IsStatePreGame() && tapStartCounter == 0)
            {
                tapStartCounter++;
                Publish(new OnReadyMessage(() =>
                {
                    _inputActionsManager.UI.TapStart.performed -= OnTapStart;
                    _inputActionsManager.Character.Enable();
                    Publish(new StartPlayMessage());
                    Publish(new GameStateMessage(Utility.EnumManager.GameState.Playing));
                }));
            }
        }

        private void OnTap(InputAction.CallbackContext context)
        {
            if (context.performed && _gameState.IsStatePlaying())
                Publish(new TapInputMessage());
        }

        private void OnTapStarted(InputAction.CallbackContext context)
        {
            if (context.started && _gameState.IsStatePlaying())
            {
                Publish(new TapStartedInputMessage());
                touchStartTime = Time.time;
            }
        }

        private void OnTapEnded(InputAction.CallbackContext context)
        {
            if (context.canceled && _gameState.IsStatePlaying())
                Publish(new TapEndedInputMessage(Time.time - touchStartTime));
        }
    }
}
