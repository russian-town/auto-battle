using System.Collections.Generic;
using Code.Gameplay.Features.Abilities.Configs;

namespace Code.Gameplay.Features.Abilities.Services
{
    public interface IAbilityRandomService
    {
        AbilityConfig GetOffensiveAbility(IEnumerable<AbilityConfig> configs);
        bool TryGetDefenceAbility(IEnumerable<AbilityConfig> configs, out AbilityConfig ability);
    }
}
