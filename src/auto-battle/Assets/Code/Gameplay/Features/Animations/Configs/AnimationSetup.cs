using System;
using System.Collections.Generic;
using Code.Gameplay.Features.AnimationEvents.Configs;

namespace Code.Gameplay.Features.Animations.Configs
{
    [Serializable]
    public class AnimationSetup
    {
        public string Name;
        public float LastFrame;
        public float Speed;
        public List<AnimationEventConfig> AnimationEventConfigs;
    }
}
