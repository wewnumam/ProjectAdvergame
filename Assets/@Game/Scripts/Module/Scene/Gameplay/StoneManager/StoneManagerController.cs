using Agate.MVC.Base;
using ProjectAdvergame.Message;
using ProjectAdvergame.Module.CameraManager;
using ProjectAdvergame.Module.Stone;
using UnityEngine;

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

            Publish<SwitchCameraMessage>(new SwitchCameraMessage(view.direction));
        }
    }
}