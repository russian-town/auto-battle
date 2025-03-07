using System;
using System.Collections.Generic;
using Code.Gameplay.Features.Motions.Configs;
using UnityEngine;

namespace Code.Gameplay.Features.Effect.Configs
{
    [Serializable]
    public class EffectSetup
    {
        [Range(0f, 1f)] public float EffectValue;
        public EffectTypeId EffectTypeId;
        public List<MotionConfig> MotionConfigs;
    }
}