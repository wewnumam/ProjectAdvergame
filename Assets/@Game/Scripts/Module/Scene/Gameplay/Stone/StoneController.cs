using Agate.MVC.Base;
using System;
using UnityEngine;

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