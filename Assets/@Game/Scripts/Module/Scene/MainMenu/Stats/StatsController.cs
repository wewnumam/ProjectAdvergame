using Agate.MVC.Base;

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
    }
}