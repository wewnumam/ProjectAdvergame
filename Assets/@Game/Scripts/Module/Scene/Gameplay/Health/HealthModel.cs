using Agate.MVC.Base;

namespace ProjectAdvergame.Module.Health
{
    public class HealthModel : BaseModel, IHealthModel
    {
        public int CurrentHealth { get; private set; }

        public void SetCurrentHealth(int currentHealth)
        {
            CurrentHealth = currentHealth;
            SetDataAsDirty();
        }

        public void IncreaseHealth()
        {
            CurrentHealth++;
            SetDataAsDirty();
        }

        public void DecreaseHealth()
        {
            CurrentHealth--;
            SetDataAsDirty();
        }
    }
}