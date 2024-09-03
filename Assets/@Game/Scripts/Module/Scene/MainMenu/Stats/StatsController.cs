using Agate.MVC.Base;
using ProjectAdvergame.Message;
using System;

namespace ProjectAdvergame.Module.Stats
{
    public class StatsController : ObjectController<StatsController, StatsModel, IStatsModel, StatsView>
    {
        public void SetCurrentHeart(int heart) => _model.SetCurrentHeart(heart);

        public void SetCurrentStar(int star) => _model.SetCurrentStar(star);

        public override void SetView(StatsView view)
        {
            base.SetView(view);
            _model.UpdateRender();
        }

        internal void OnUnlockCharacter(UnlockCharacterMessage message)
        {
            _model.SubtractHeart(message.CharacterData.cost);
        }

        internal void OnUnlockLevel(UnlockLevelMessage message)
        {
            _model.SubtractHeart(message.LevelItem.cost);
        }
    }
}