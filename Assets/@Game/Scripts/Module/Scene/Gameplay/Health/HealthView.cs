using Agate.MVC.Base;
using TMPro;

namespace ProjectAdvergame.Module.Health
{
    public class HealthView : ObjectView<IHealthModel>
    {
        public TMP_Text healthText;

        protected override void InitRenderModel(IHealthModel model)
        {
        }

        protected override void UpdateRenderModel(IHealthModel model)
        {
            healthText.SetText(model.CurrentHealth.ToString());
        }
    }
}