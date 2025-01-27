using System;
using System.Collections.Generic;
using Code.Gameplay.Features.Effect.Configs;

namespace Code.Gameplay.Features.Animations.Configs
{
    [Serializable]
    public class EventSetup
    {
        public List<EffectSetup> EffectSetups;
        public float CaptureOnTimeline;

        public EventSetup(float captureOnTimeline)
        {
            CaptureOnTimeline = captureOnTimeline;
        }
    }
}
