using Agate.MVC.Base;
using ProjectAdvergame.Message;
using ProjectAdvergame.Utility;

namespace ProjectAdvergame.Module.Health
{
    public class HealthController : ObjectController<HealthController, HealthModel, IHealthModel, HealthView>
    {
        public void SetCurrentHealth(int amount) => _model.SetCurrentHealth(amount);

        internal void DecreaseHealth(BeatAccuracyMessage message)
        {
            if (message.BeatAccuracy != EnumManager.BeatAccuracy.Perfect)
                _model.DecreaseHealth();

            if (_model.CurrentHealth < 1)
                Publish(new GameOverMessage());
        }

        internal void IncreaseHealth(AddHealthMessage message)
        {
            _model.IncreaseHealth();
        }
    }
}