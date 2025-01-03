using System;
using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Configs;
using UnityEngine;

namespace Code.Gameplay.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<AbilityTypeId, AbilityConfig> _abilityById = new();

        public void LoadAll()
        {
            LoadAbilities();
        }

        public AbilityConfig GetAbilityConfig(AbilityTypeId abilityTypeId)
        {
            if (_abilityById.TryGetValue(abilityTypeId, out AbilityConfig config))
                return config;

            throw new Exception($"Ability config for {abilityTypeId} was not found.");
        }

        /*public AbilityLevel GetAbilityLevel(AbilityTypeId abilityTypeId, int level)
        {
            var config = GetAbilityConfig(abilityTypeId);

            if (level > config.Levels.Count)
                level = config.Levels.Count;

            return config.Levels[level - 1];
        }*/

        private void LoadAbilities()
        {
            _abilityById = Resources
                .LoadAll<AbilityConfig>("Configs/Abilities")
                .ToDictionary(x => x.AbilityTypeId, x => x);
        }
    }
}
