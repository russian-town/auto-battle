﻿using Code.Gameplay.Features.Abilities.Configs;

namespace Code.Gameplay.Features.Abilities.Factory
{
    public interface IAbilityFactory
    {
        GameEntity CreateAbility(AbilityTypeId typeId, int producerId, int targetId);
    }
}
