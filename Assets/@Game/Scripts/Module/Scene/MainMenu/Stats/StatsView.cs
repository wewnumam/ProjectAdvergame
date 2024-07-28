using Agate.MVC.Base;
using TMPro;

namespace ProjectAdvergame.Module.Stats
{
    public class StatsView : ObjectView<IStatsModel>
    {
        public TMP_Text heartText;
        public TMP_Text starText;

        protected override void InitRenderModel(IStatsModel model)
        {
        }

        protected override void UpdateRenderModel(IStatsModel model)
        {
            heartText.SetText(model.CurrentHeart.ToString());
            starText.SetText(model.CurrentStar.ToString());
        }
    }
}