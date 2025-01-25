using System;
using System.Collections.Generic;
using Code.Gameplay.Features.Effect.Configs;
using Code.Gameplay.Features.Statuses.Configs;

namespace Code.Gameplay.Features.Animations.Configs
{
    [Serializable]
    public class EventSetup
    {
        public List<EffectSetup> EffectSetups;
        public List<StatusSetup> StatusSetups;
        public float CaptureOnTimeline;

        public EventSetup(float captureOnTimeline)
        {
            CaptureOnTimeline = captureOnTimeline;
        }
    }
}
