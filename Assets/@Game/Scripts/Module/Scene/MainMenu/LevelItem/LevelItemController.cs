using Agate.MVC.Base;
using ProjectAdvergame.Message;
using UnityEngine;

namespace ProjectAdvergame.Module.LevelItem
{
    public class LevelItemController : ObjectController<LevelItemController, LevelItemView>
    {
        public void Init(LevelItemView levelItemView)
        {
            SetView(levelItemView);
        }

        public override void SetView(LevelItemView view)
        {
            base.SetView(view);
            view.SetCallback(OnChooseLevel);
        }

        private void OnChooseLevel()
        {
            Publish(new ChooseLevelMessage(_view.levelData.name));
        }
    }
}