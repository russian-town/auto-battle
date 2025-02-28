using Code.Gameplay.Features.HealthBar.Behaviours;
using Code.Infrastructure.Views.Registrars;

namespace Code.Gameplay.Features.HealthBar.Registrars
{
    public class FighterHealthBarRegistrar : EntityComponentRegistrar
    {
        public FighterHealthBar FighterHealthBar;
        
        public override void RegisterComponents() => Entity.AddFighterHealthBar(FighterHealthBar);

        public override void UnregisterComponents()
        {
            if (Entity.hasFighterHealthBar)
                Entity.RemoveFighterHealthBar();
        }
    }
}
