using Agate.MVC.Base;
using TMPro;
using UnityEngine;

namespace ProjectAdvergame.Module.Health
{
    public class HealthView : ObjectView<IHealthModel>
    {
        public TMP_Text healthText;
        [Header("Debug")] public bool isImmortal;

        protected override void InitRenderModel(IHealthModel model)
        {
        }

        protected override void UpdateRenderModel(IHealthModel model)
        {
            healthText.SetText(model.CurrentHealth.ToString());
        }
    }
}