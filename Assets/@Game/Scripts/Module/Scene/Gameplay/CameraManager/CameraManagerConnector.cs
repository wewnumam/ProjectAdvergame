using Agate.MVC.Base;
using ProjectAdvergame.Message;

namespace ProjectAdvergame.Module.CameraManager
{
    public class CameraManagerConnector : BaseConnector
    {
        private CameraManagerController _cameraManager;

        protected override void Connect()
        {
            Subscribe<SwitchCameraMessage>(_cameraManager.SwitchCamera);
        }

        protected override void Disconnect()
        {
            Unsubscribe<SwitchCameraMessage>(_cameraManager.SwitchCamera);
        }
    }
}