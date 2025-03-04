﻿using Code.Gameplay.Features.Abilities.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Abilities
{
    public class AbilityFeature : Feature
    {
        public AbilityFeature(ISystemFactory systems)
        {
            Add(systems.Create<DefaultAttackAbilitySystem>());
            
            //Add(systems.Create<CleanupAbilitySystem>());
        }
    }
}
