using System.Collections.Generic;
using Code.Gameplay.Features.Abilities.Configs;

namespace Code.Gameplay.Features.Abilities.Services
{
    public interface IAbilityRandomService
    {
        AbilityConfig GetRandomAbility(IEnumerable<AbilityConfig> configs);
    }
}
