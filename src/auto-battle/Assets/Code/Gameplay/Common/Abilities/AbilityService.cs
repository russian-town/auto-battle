using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Common.Random;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.StaticData;
using UnityEngine;

namespace Code.Gameplay.Common.Abilities
{
    public class AbilityService : IAbilityService
    {
        private readonly IRandomService _random;
        private readonly IStaticDataService _staticDataService;
        private List<AbilityConfig> _abilities;

        public AbilityService(IRandomService random)
        {
            _random = random;
            LoadAll();
        }

        public void LoadAll()
        {
            LoadAbilities();
        }

        public AbilityConfig GetRandomAbilities() =>
            _abilities.FirstOrDefault(ability => ability.Chance >= _random.Range(0f, 1f));

        private void LoadAbilities()
        {
            _abilities = Resources.LoadAll<AbilityConfig>("Configs/Abilities").ToList();
        }
    }
}
