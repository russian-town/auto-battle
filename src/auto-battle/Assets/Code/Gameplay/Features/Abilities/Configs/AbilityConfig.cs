using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Features.Effect.Configs;
using Code.Gameplay.Features.Statuses.Configs;
using UnityEngine;

namespace Code.Gameplay.Features.Abilities.Configs
{
    [CreateAssetMenu(fileName = "AbilityConfig", menuName = "auto-battle/Abilities", order = 59)]
    public class AbilityConfig : ScriptableObject
    {
        [Range(0f, 1f)] public float Chance;
        public AbilityTypeId AbilityTypeId;
        public List<EffectSetup> EffectSetups;
        public List<StatusSetup> StatusSetups;
        public float TargetDistance;

        public float Cooldown() =>
            EffectSetups.Sum(effect => effect.Cooldown);
    }
}
