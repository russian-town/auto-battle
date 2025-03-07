using System;
using System.Collections.Generic;
using Code.Gameplay.Features.Effect.Configs;
using Code.Gameplay.Features.Statuses.Configs;

namespace Code.Gameplay.Features.AnimationEvents.Configs
{
    [Serializable]
    public class AnimationEventSetup
    {
        public float TargetFrame;
        public List<EffectSetup> EffectSetups;
        public List<StatusSetup> StatusSetups;
    }
}
