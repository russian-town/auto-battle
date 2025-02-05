using System;
using System.Collections.Generic;

namespace Code.Gameplay.Features.Animations.Configs
{
    [Serializable]
    public class AnimationSetup
    {
        public AnimationTypeId TypeId;
        public List<EventSetup> EventSetups;
        public float TargetDistance;

        public AnimationSetup(AnimationTypeId typeId, List<EventSetup> eventSetups = null)
        {
            TypeId = typeId;
            EventSetups = eventSetups;
        }
    }
}
