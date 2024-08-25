using Agate.MVC.Base;
using ProjectAdvergame.Message;


namespace ProjectAdvergame.Module.CharacterItem
{
    public class CharacterItemController : ObjectController<CharacterItemController, CharacterItemModel, ICharacterItemModel, CharacterItemView>
    {
        public void SetCurrentHeartCount(int count) => _model.SetCurrentHeartCount(count);

        public void SubstractHeart(int cost) => _model.SubtractHeart(cost);

        public void Init(CharacterItemModel model, CharacterItemView view)
        {
            _model = model;
            SetView(view);
        }

        public override void SetView(CharacterItemView view)
        {
            base.SetView(view);
            view.SetCallback(OnChooseLevel, OnUnlockLevel, OnSubstractHeart);
        }

        private void OnChooseLevel()
        {
            Publish(new ChooseCharacterMessage(_view.characterData.name));
        }

        private void OnUnlockLevel()
        {
            _view.chooseButton.gameObject.SetActive(true);
            _view.unlockButton.gameObject.SetActive(false);
            Publish(new UnlockCharacterMessage(_view.characterData));
        }

        private void OnSubstractHeart(int cost)
        {
            _model.SubtractHeart(cost);
        }
    }
}