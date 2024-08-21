using Agate.MVC.Base;
using ProjectAdvergame.Message;
using System;

namespace ProjectAdvergame.Module.Stone
{
    public class StoneController : ObjectController<StoneController, StoneView>
    {
        public void Init(StoneView view)
        {
            SetView(view);
            view.SetCallback(OnComplete);
        }

        private void OnComplete()
        {
            Publish(new CurrentZPositionMessage(_view.transform.position.z));
        }
    }
}