using Agate.MVC.Base;
using ProjectAdvergame.Message;
using ProjectAdvergame.Module.GameState;
using System;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace ProjectAdvergame.Module.Input
{
    public class TapInputController : BaseController<TapInputController>
    {
        private GameStateController _gameState;
        private InputActionManager _inputActionsManager = new InputActionManager();

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
            Publish(new GamePauseMessage());
        }

        public void OnGameOver(GameOverMessage message)
        {
            _inputActionsManager.Character.Disable();
        }

        private void OnTapStart(InputAction.CallbackContext context)
        {
            if (context.performed && _gameState.IsStatePreGame())
            {
                _inputActionsManager.UI.TapStart.performed -= OnTapStart;
                _inputActionsManager.Character.Enable();
                Publish(new StartPlayMessage());
                Publish(new GameStateMessage(Utility.EnumManager.GameState.Playing));
            }
        }

        private void OnTap(InputAction.CallbackContext context)
        {
            if (context.performed && _gameState.IsStatePlaying())
            {
                Publish(new TapInputMessageMessage());
            }
        }
    }
}
