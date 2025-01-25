using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code.Gameplay.Features.Animations.Configs
{
    [Serializable]
    public class AnimationSetup
    {
        public AnimationTypeId TypeId;
        public float TargetDistance;
        public float AnimationTime;
        
        public AnimationSetup(AnimationTypeId typeId, float animationTime, float targetDistance)
        {
            TypeId = typeId;
            AnimationTime = animationTime;
            TargetDistance = targetDistance;
        }
    }
}
