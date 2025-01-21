using System.Collections.Generic;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.CharacterStats;
using Code.Gameplay.Features.CharacterStats.Configs;
using Code.Infrastructure.Views;
using UnityEngine;

namespace Code.Gameplay.Features.Fighter.Configs
{
    [CreateAssetMenu(fileName = "FighterConfig", menuName = "auto-battle/Fighters", order = 59)]
    public class FighterConfig : ScriptableObject
    {
        public EntityBehaviour View;
        public List<StatsSetup> StatsSetups;
        public List<AbilityConfig> BaseAbilities;
        public float Speed = 3f;

        public Dictionary<Stats, float> GetStats()
        {
            var statByType = new Dictionary<Stats, float>();

            foreach (var statsSetup in StatsSetups)
                statByType[statsSetup.Stats] = statsSetup.Value;

            return statByType;
        }
    }
}
