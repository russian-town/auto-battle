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
        public List<AnimationClip> Clips;
        public float TargetDistance;
        
        public float AnimationTime => Clips.Sum(x => x.length);

        public AnimationSetup(AnimationTypeId typeId, float targetDistance)
        {
            TypeId = typeId;
            TargetDistance = targetDistance;
        }
    }
}
