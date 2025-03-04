using Code.Gameplay.Features.Effect.Behaviours;
using Code.Infrastructure.Views.Registrars;

namespace Code.Gameplay.Features.Effect.Registrars
{
    public class EffectWindowRegistrar : EntityComponentRegistrar
    {
        public EffectWindow EffectWindow;
        
        public override void RegisterComponents() => Entity.AddEffectWindow(EffectWindow);

        public override void UnregisterComponents()
        {
            if (Entity.hasEffectWindow)
                Entity.RemoveEffectWindow();
        }
    }
}
