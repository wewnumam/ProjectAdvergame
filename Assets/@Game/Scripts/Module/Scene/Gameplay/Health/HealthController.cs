using Agate.MVC.Base;
using ProjectAdvergame.Message;
using ProjectAdvergame.Utility;
using System;

namespace ProjectAdvergame.Module.Health
{
    public class HealthController : ObjectController<HealthController, HealthModel, IHealthModel, HealthView>
    {
        public void SetCurrentHealth(int amount) => _model.SetCurrentHealth(amount);

        public override void SetView(HealthView view)
        {
            base.SetView(view);
            foreach (var item in _view.healthObjects)
                item.SetActive(false);
        }

        internal void DecreaseHealth(BeatAccuracyMessage message)
        {
            if (message.BeatAccuracy == EnumManager.BeatAccuracy.Late && message.StoneType != EnumManager.StoneType.LongBeat)
            {
                _view.isIncrease = false;
                _model.DecreaseHealth();
            }
        }

        internal void IncreaseHealth(AddHealthMessage message)
        {
            _view.isIncrease = true;
            _model.IncreaseHealth();
        }

        internal void OnGameWin(GameWinMessage message)
        {
            Publish(new GameResultHeartMessage(_model.CurrentHealth));

            foreach (var item in _view.healthObjects)
                item.SetActive(false);
        }

        internal void OnReady(OnReadyMessage message)
        {
            _model.UpdateRender();
        }
    }
}