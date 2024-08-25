using Agate.MVC.Base;

namespace ProjectAdvergame.Module.CharacterItem
{
    public interface ICharacterItemModel : IBaseModel
    {
        int CurrentHeartCount { get; }
    }
}