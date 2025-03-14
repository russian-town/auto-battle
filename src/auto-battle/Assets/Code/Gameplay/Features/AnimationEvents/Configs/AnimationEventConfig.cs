﻿using System.Collections.Generic;
using Code.Gameplay.Features.Effect.Configs;
using Code.Gameplay.Features.Statuses.Configs;
using UnityEngine;

namespace Code.Gameplay.Features.AnimationEvents.Configs
{
    [CreateAssetMenu(fileName = "AnimationEventConfig", menuName = "auto-battle/AnimationEvents", order = 59)]
    public class AnimationEventConfig : ScriptableObject
    {
        public float TargetFrame;
        public List<EffectSetup> EffectSetups;
        public List<StatusSetup> StatusSetups;
    }
}
