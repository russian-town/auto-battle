using Code.Gameplay.Features.Effect.System;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Effect
{
    public class EffectFeature : Feature
    {
        public EffectFeature(ISystemFactory systems)
        {
            Add(systems.Create<RemoveEffectsWithoutTargetSystem>());
            
            Add(systems.Create<CreateAnimationForBlockStatusSystem>());
            Add(systems.Create<CreateAnimationForDodgeStatusSystem>());
            
            Add(systems.Create<RemoveEffectDamageAbsorptionStatusSystem>());
            
            Add(systems.Create<ProcessDamageEffectSystem>());
            Add(systems.Create<ProcessHealEffectSystem>());
            
            Add(systems.Create<CleanupProcessedEffectsSystem>());
        }
    }
}
