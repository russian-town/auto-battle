using System;
using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.Buffs;
using Code.Gameplay.Features.Buffs.Configs;
using Code.Gameplay.Features.Fighter.Configs;
using UnityEngine;

namespace Code.Gameplay.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<AbilityTypeId, AbilityConfig> _abilityById = new();
        private List<FighterConfig> _fighterConfigs = new();
        private Dictionary<BuffTypeId, BuffConfig> _buffById = new();

        public StaticDataService()
        {
            LoadAll();
        }

        public void LoadAll()
        {
            LoadAbilities();
            LoadFighters();
        }

        public AbilityConfig GetAbilityConfig(AbilityTypeId abilityTypeId)
        {
            if (_abilityById.TryGetValue(abilityTypeId, out var config))
                return config;

            throw new Exception($"Ability config for {abilityTypeId} was not found.");
        }

        public FighterConfig GetFighterConfig() =>
            _fighterConfigs.FirstOrDefault();
        
        public BuffConfig GetBuffConfig(BuffTypeId typeId) => throw new NotImplementedException();

        /*public AbilityLevel GetAbilityLevel(AbilityTypeId abilityTypeId, int level)
        {
            var config = GetAbilityConfig(abilityTypeId);

            if (level > config.Levels.Count)
                level = config.Levels.Count;

            return config.Levels[level - 1];
        }*/

        private void LoadAbilities() =>
            _abilityById = Resources
                .LoadAll<AbilityConfig>("Configs/Abilities")
                .ToDictionary(x => x.AbilityTypeId, x => x);

        private void LoadFighters() =>
            _fighterConfigs = Resources
                .LoadAll<FighterConfig>("Configs/Fighters")
                .ToList();
        
        private void LoadBuffs() =>
            _buffById = Resources
                .LoadAll<BuffConfig>("Configs/Abilities")
                .ToDictionary(x => x.TypeId, x => x);
    }
}
