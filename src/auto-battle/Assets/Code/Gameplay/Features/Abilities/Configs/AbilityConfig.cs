﻿using System.Collections.Generic;
using Code.Gameplay.Features.Motions.Configs;
using UnityEditor.Animations;
using UnityEngine;

namespace Code.Gameplay.Features.Abilities.Configs
{
    [CreateAssetMenu(fileName = "AbilityConfig", menuName = "auto-battle/Abilities", order = 59)]
    public class AbilityConfig : ScriptableObject
    {
        [Range(0f, 1f)] public float Chance;
        public AnimatorController AnimatorController;
        
        public int ManaCost;
        public AbilityTypeId AbilityTypeId;
        public List<MotionConfig> MotionConfigs;
    }
}