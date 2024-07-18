using Agate.MVC.Base;
using ProjectAdvergame.Utility;
using System.Collections.Generic;

namespace ProjectAdvergame.Module.Health
{
    public interface IHealthModel : IBaseModel
    {
        int CurrentHealth { get; }
    }
}