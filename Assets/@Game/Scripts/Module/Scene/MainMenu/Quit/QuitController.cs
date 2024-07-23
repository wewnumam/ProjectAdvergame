using Agate.MVC.Base;
using ProjectAdvergame.Message;
using ProjectAdvergame.Module.Input;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectAdvergame.Module.Quit
{
    public class QuitController : ObjectController<QuitController, QuitView>
    {
        private InputActionManager _inputActionsManager = new InputActionManager();
        int quitPerformedCounter;

        public override IEnumerator Initialize()
        {
            yield return base.Initialize();

            _inputActionsManager.MainMenu.Quit.Enable();
            _inputActionsManager.MainMenu.Quit.performed += OnQuit;
        }

        public override IEnumerator Terminate()
        {
            _inputActionsManager.MainMenu.Quit.performed -= OnQuit;
            _inputActionsManager.MainMenu.Quit.Disable();

            yield return base.Terminate();
        }

        public override void SetView(QuitView view)
        {
            base.SetView(view);
            view.SetCallback(OnClose);
        }

        private void OnClose()
        {
            quitPerformedCounter = 0;
            _view.Hide();
        }

        private void OnQuit(InputAction.CallbackContext context)
        {
            if (quitPerformedCounter == 0)
                _view.Show();
            else if (quitPerformedCounter > 0)
                Application.Quit();

            quitPerformedCounter++;
        }
    }
}