using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Common.Random;
using Code.Gameplay.Features.Abilities.Configs;

namespace Code.Gameplay.Features.Abilities.Services
{
    public class AbilityRandomService : IAbilityRandomService
    {
        private readonly IRandomService _random;

        private AbilityConfig _currentAbility;
        
        public AbilityRandomService(IRandomService random) => _random = random;

        public AbilityConfig GetOffensiveAbility(IEnumerable<AbilityConfig> configs)
        {
            Cleanup();
            var chance = _random.Range(0f, 1f);

            _currentAbility = configs
                .Where(x => x.AttackTypeId == AttackTypeId.Offensive)
                .OrderBy(x => x.Chance)
                .FirstOrDefault(x => x.Chance >= chance);

            return _currentAbility;
        }

        public bool TryGetDefenceAbility(IEnumerable<AbilityConfig> configs, out AbilityConfig ability)
        {
            if (IsNullOrNotDefault())
            {
                ability = null;
                return false;
            }

            var chance = _random.Range(0f, 1f);
            
            var config = configs
                .Where(x => x.AttackTypeId == AttackTypeId.Offensive)
                .OrderBy(x => x.Chance)
                .FirstOrDefault(x => x.Chance >= chance);

            if (config == null)
            {
                ability = null;
                return false;
            }

            ability = config;
            return true;
        }

        private void Cleanup() => _currentAbility = null;
        
        private bool IsNullOrNotDefault()
        {
            return _currentAbility == null
                   || _currentAbility.AbilityTypeId
                   != AbilityTypeId.DefaultAttack;
        }
    }
}
