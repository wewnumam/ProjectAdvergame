using Agate.MVC.Base;
using ProjectAdvergame.Module.LevelData;
using System.Collections.Generic;

namespace ProjectAdvergame.Module.LevelItem
{
    public interface ILevelItemModel : IBaseModel
    {
        int CurrentHeartCount { get; }
    }
}