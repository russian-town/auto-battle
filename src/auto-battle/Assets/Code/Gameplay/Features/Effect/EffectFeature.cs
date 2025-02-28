﻿using Code.Gameplay.Features.Effect.System;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Effect
{
    public class EffectFeature : Feature
    {
        public EffectFeature(ISystemFactory systems)
        {
            Add(systems.Create<RemoveEffectsWithoutTargetSystem>());
            Add(systems.Create<RemoveBlockedEffectsSystem>());
            
            Add(systems.Create<ProcessDamageEffectSystem>());
            Add(systems.Create<ProcessHealEffectSystem>());
            Add(systems.Create<ProcessPushEffectSystem>());
            
            Add(systems.Create<AnimateFighterBlockSystem>());
            Add(systems.Create<AnimateFighterDodgeSystem>());
            
            Add(systems.Create<CleanupProcessedEffectsSystem>());
        }
    }
}
