using Agate.MVC.Base;
using UnityEngine;

namespace ProjectAdvergame.Module.Stone
{
    public class StoneController : ObjectController<StoneController, StoneView>
    {
        public void Init(StoneView view)
        {
            SetView(view);
        }

        public override void SetView(StoneView view)
        {
            base.SetView(view);
            Debug.Log(view.gameObject.name);
        }
    }
}