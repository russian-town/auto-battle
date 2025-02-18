﻿using System.Collections.Generic;
using Code.Gameplay.Features.AnimationEvents.Configs;
using UnityEngine;

namespace Code.Gameplay.Features.Abilities.Configs
{
    [CreateAssetMenu(fileName = "AbilityConfig", menuName = "auto-battle/Abilities", order = 59)]
    public class AbilityConfig : ScriptableObject
    {
        [Range(0f, 1f)] public float Chance;
        
        public float TargetDistance;
        public AbilityTypeId AbilityTypeId;
        public List<AnimationEventSetup> AnimationEventSetups;
    }
}