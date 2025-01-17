using Code.Gameplay.Features.Damage.Behaviours;
using Code.Infrastructure.Views.Registrars;

namespace Code.Gameplay.Features.Damage.Registrars
{
    public class HealthBarRegistrar : EntityComponentRegistrar
    {
        public HealthBar HealthBar;
        
        public override void RegisterComponents() =>
            Entity.AddHealthBar(HealthBar);

        public override void UnregisterComponents()
        {
            if (Entity.hasHealthBar)
                Entity.RemoveHealthBar();
        }
    }
}
