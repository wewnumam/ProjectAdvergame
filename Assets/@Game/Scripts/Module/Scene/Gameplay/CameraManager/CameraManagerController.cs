using Agate.MVC.Base;
using DG.Tweening;
using ProjectAdvergame.Message;
using ProjectAdvergame.Utility;
using UnityEngine;

namespace ProjectAdvergame.Module.CameraManager
{
    public class CameraManagerController : ObjectController<CameraManagerController, CameraManagerView>
    {
        internal void SwitchCamera(SwitchCameraMessage message)
        {
            if (message.Direction == EnumManager.Direction.FromEast)
            {
                _view.cameraEast.enabled = false;
                _view.cameraWest.enabled = true;
                _view.cameraSouth.enabled = false;
            }
            else if (message.Direction == EnumManager.Direction.FromWest)
            {
                _view.cameraEast.enabled = true;
                _view.cameraWest.enabled = false;
                _view.cameraSouth.enabled = false;
            }
            else
            {
                _view.cameraEast.enabled = false;
                _view.cameraWest.enabled = false;
                _view.cameraSouth.enabled = true;
            }
        }
    }
}