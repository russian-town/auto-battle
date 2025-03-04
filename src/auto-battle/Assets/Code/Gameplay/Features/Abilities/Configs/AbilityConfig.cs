using System.Collections.Generic;
using Code.Gameplay.Features.Effect.Configs;
using Code.Gameplay.Features.Statuses.Configs;
using UnityEngine;

namespace Code.Gameplay.Features.Abilities.Configs
{
    [CreateAssetMenu(fileName = "AbilityConfig", menuName = "auto-battle/Abilities", order = 59)]
    public class AbilityConfig : ScriptableObject
    {
        [Range(0f, 1f)] public float Chance;

        public float BaseDuration = 1f;
        
        public int ManaCost;
        public AbilityTypeId AbilityTypeId;
        public List<EffectSetup> EffectSetups;
        public List<StatusSetup> StatusSetups;
        public AnimationClip AnimationClip;

        private void OnValidate()
        {
            if (AnimationClip != null)
                BaseDuration = 1f + AnimationClip.length;
        }
    }
}