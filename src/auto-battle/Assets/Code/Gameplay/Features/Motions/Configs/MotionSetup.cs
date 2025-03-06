using System;
using System.Collections.Generic;
using Code.Gameplay.Features.Effect.Configs;
using Code.Gameplay.Features.Statuses.Configs;

namespace Code.Gameplay.Features.Motions.Configs
{
    [Serializable]
    public class MotionSetup
    {
        public string MotionName;
        public float EventFrame;
        public float MaxFrame;
        public List<EffectSetup> EffectSetups;
        public List<StatusSetup> StatusSetups;
    }
}
