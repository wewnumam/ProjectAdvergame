using Agate.MVC.Base;
using ProjectAdvergame.Message;

namespace ProjectAdvergame.Module.LoadNotification
{
    public class LoadNotificationController : ObjectController<LoadNotificationController, LoadNotificationView>
    {
        internal void Show(OnFailedToLoadAssetMessage message)
        {
            _view.gameObject.SetActive(true);
        }
    }
}