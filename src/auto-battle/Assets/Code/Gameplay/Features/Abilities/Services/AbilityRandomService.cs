using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Common.Random;
using Code.Gameplay.Features.Abilities.Configs;

namespace Code.Gameplay.Features.Abilities.Services
{
    public class AbilityRandomService : IAbilityRandomService
    {
        private readonly IRandomService _random;
        public AbilityRandomService(IRandomService random) => _random = random;

        public AbilityConfig GetRandomAbility(IEnumerable<AbilityConfig> configs)
        {
            var chance = _random.Range(0f, 1f);

            return configs
                //.Where(x => x.TurnTypeId == TurnTypeId.Offensive)
                .OrderBy(x => x.Chance)
                .First(x => x.Chance >= chance);
        }
    }
}
