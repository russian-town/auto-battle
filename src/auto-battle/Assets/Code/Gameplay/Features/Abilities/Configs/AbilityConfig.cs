using System.Collections.Generic;
using Code.Common.Extensions;
using Code.Gameplay.Features.Animations.Configs;
using UnityEngine;

namespace Code.Gameplay.Features.Abilities.Configs
{
    [CreateAssetMenu(fileName = "AbilityConfig", menuName = "auto-battle/Abilities", order = 59)]
    public class AbilityConfig : ScriptableObject
    {
        [Range(0f, 1f)] public float Chance;
        public int ManaCost;
        public AbilityTypeId AbilityTypeId;
        public List<AnimationSetup> AnimationSetups;
        public float Cooldown;
        public int Lifetime;
        public AttackTypeId AttackTypeId;
        public List<Stage> Stages;

        private void OnValidate()
        {
            if(AnimationSetups.IsNullOrEmpty())
                return;
            
            foreach (var animationSetup in AnimationSetups)
                animationSetup.Initialize();
        }
    }
}