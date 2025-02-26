using System.Collections.Generic;
using Code.Gameplay.Features.Animations.Configs;
using Code.Gameplay.Features.Movement.Config;
using UnityEngine;

namespace Code.Gameplay.Features.Abilities.Configs
{
    [CreateAssetMenu(fileName = "AbilityConfig", menuName = "auto-battle/Abilities", order = 59)]
    public class AbilityConfig : ScriptableObject
    {
        [Range(0f, 1f)] public float Chance;

        public MovementSetup MovementSetup;
        public int StepsToTarget;
        public float TargetDistance;
        public AbilityTypeId AbilityTypeId;
        public List<AnimationSetup> AnimationSetups;
    }
}