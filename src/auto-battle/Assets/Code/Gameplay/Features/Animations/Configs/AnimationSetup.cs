using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Features.Animations.Configs
{
    [Serializable]
    public class AnimationSetup
    {
        public AnimationTypeId TypeId;
        public List<EventSetup> EventSetups;
        public float TargetDistance;
        public float AnimationTime;

        public AnimationSetup(AnimationTypeId typeId, List<EventSetup> eventSetups, float targetDistance, float animationTime)
        {
            TypeId = typeId;
            EventSetups = eventSetups;
            TargetDistance = targetDistance;
            AnimationTime = animationTime;
        }
    }
}
