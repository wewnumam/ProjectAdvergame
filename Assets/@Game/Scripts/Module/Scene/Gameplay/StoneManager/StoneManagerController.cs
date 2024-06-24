using Agate.MVC.Base;
using DG.Tweening;
using ProjectAdvergame.Message;
using ProjectAdvergame.Module.Stone;

namespace ProjectAdvergame.Module.StoneManager
{
    public class StoneManagerController : ObjectController<StoneManagerController, StoneManagerView>
    {
        public override void SetView(StoneManagerView view)
        {
            base.SetView(view);
            foreach (var stone in view.stones)
            {
                StoneController stoneController = new StoneController();
                InjectDependencies(stoneController);
                stoneController.Init(stone);
            }
        }
    }
}