using Agate.MVC.Base;
using ProjectAdvergame.Message;


namespace ProjectAdvergame.Module.LevelItem
{
    public class LevelItemController : ObjectController<LevelItemController, LevelItemModel, ILevelItemModel, LevelItemView>
    {
        public void SetCurrentHeartCount(int count) => _model.SetCurrentHeartCount(count);

        public void SubstractHeart(int cost) => _model.SubtractHeart(cost);

        public void Init(LevelItemModel model, LevelItemView view)
        {
            _model = model;
            SetView(view);
        }

        public override void SetView(LevelItemView view)
        {
            base.SetView(view);
            view.SetCallback(OnChooseLevel, OnUnlockLevel, OnSubstractHeart);
        }

        private void OnChooseLevel()
        {
            Publish(new ChooseLevelMessage(_view.levelData.name));
        }

        private void OnUnlockLevel()
        {
            _view.chooseButton.gameObject.SetActive(true);
            _view.unlockButton.gameObject.SetActive(false);
            Publish(new UnlockLevelMessage(_view.levelItem));
        }

        private void OnSubstractHeart(int cost)
        {
            _model.SubtractHeart(cost);
        }
    }
}