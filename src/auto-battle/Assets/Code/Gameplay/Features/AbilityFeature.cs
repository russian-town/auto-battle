﻿using Code.Gameplay.Features.Abilities.System;
using Code.Gameplay.Features.Cooldowns.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features
{
    public class AbilityFeature : Feature
    {
        public AbilityFeature(ISystemFactory systems)
        {
            Add(systems.Create<CooldownSystem>());
            Add(systems.Create<BlockAbilitySystem>());
        }
    }
}
