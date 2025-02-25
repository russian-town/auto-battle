using System;
using System.Collections.Generic;
using Code.Gameplay.Features.Effect.Configs;
using Code.Gameplay.Features.Statuses.Configs;
using UnityEngine;

namespace Code.Gameplay.Features.Animations.Configs
{
    [Serializable]
    public class EventSetup
    {
        [Range(0f, 1f)] public float AnimationPercent;
        public List<EffectSetup> EffectSetups;
        public List<StatusSetup> StatusSetups;
    }
}
