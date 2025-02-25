using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Features.Animations.Configs
{
    [Serializable]
    public class AnimationSetup
    {
        public AnimationClip Clip;
        public List<EventSetup> EventSetups;
    }
}
