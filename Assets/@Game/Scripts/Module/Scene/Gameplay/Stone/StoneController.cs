using Agate.MVC.Base;
using ProjectAdvergame.Message;

namespace ProjectAdvergame.Module.Stone
{
    public class StoneController : ObjectController<StoneController, StoneView>
    {
        public void Init(StoneView view)
        {
            SetView(view);
        }
    }
}