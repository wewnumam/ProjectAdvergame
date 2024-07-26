using Agate.MVC.Base;
using ProjectAdvergame.Utility;

namespace ProjectAdvergame.Module.SaveSystem
{
    public interface ISaveSystemModel : IBaseModel
    {
        public SaveData SaveData { get; }
    }
}