using Agate.MVC.Base;
using DG.Tweening;
using ProjectAdvergame.Message;

namespace ProjectAdvergame.Module.PlayerCharacter
{
    public class PlayerCharacterController : ObjectController<PlayerCharacterController, PlayerCharacterView>
    {
        internal void OnMove(MovePlayerCharacterMessage message)
        {
            _view.transform.DOMoveZ(_view.transform.position.z + 1, .1f);
        }
    }
}