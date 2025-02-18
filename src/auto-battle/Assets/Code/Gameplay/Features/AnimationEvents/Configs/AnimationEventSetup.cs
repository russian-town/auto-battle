using System;
using System.Collections.Generic;
using Code.Gameplay.Features.Effect.Configs;
using Code.Gameplay.Features.Statuses.Configs;
using UnityEngine;

namespace Code.Gameplay.Features.AnimationEvents.Configs
{
    [Serializable]
    public class AnimationEventSetup
    {
        public AnimationClip TargetAnimation;
        public List<EffectSetup> EffectSetups;
        public List<StatusSetup> StatusSetups;
        public float Delay;

        public int HashCode => TargetAnimation.GetHashCode();
    }
}
