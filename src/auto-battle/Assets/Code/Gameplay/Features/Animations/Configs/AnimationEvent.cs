using System;
using System.Collections.Generic;
using Code.Gameplay.Features.Effect.Configs;
using Code.Gameplay.Features.Statuses.Configs;
using UnityEngine;

namespace Code.Gameplay.Features.Animations.Configs
{
    [Serializable]
    public class AnimationEvent
    {
        public float TargetFrame;
        public List<EffectSetup> EffectSetups;
        public List<StatusSetup> StatusSetups;

        public void OnValidate(float maxFrame) => TargetFrame = Mathf.Clamp(TargetFrame, 0, maxFrame);
    }
}
