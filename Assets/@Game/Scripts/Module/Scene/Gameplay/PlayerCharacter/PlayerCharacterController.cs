using Agate.MVC.Base;
using DG.Tweening;
using ProjectAdvergame.Message;
using UnityEngine;

namespace ProjectAdvergame.Module.PlayerCharacter
{
    public class PlayerCharacterController : ObjectController<PlayerCharacterController, PlayerCharacterView>
    {
        public override void SetView(PlayerCharacterView view)
        {
            base.SetView(view);
            view.SetCallback(StoneState);
        }

        private void StoneState(string state, GameObject stoneObject)
        {
            Debug.Log($"{stoneObject.name} [{state}]");
        }

        internal void OnMove(MovePlayerCharacterMessage message)
        {
            _view.transform.DOMoveZ(_view.transform.position.z + 1, .1f);
        }
    }
}