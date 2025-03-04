using System;
using System.Collections.Generic;
using System.Linq;
using Code.Common.Extensions;
using UnityEditor.Animations;
using UnityEngine;

namespace Code.Gameplay.Features.Animations.Configs
{
    [Serializable] public class AnimationSetup
    {
        public string StateName;
        public int HashCode;

        [Range(0f, 1f)] public float DurationTime;
        [Range(0f, 1f)] public float TransitionTime;

        public AnimationClip AnimationClip;
        public float AllFrames;
        public List<AnimationEvent> AnimationEvents;

        public void OnValidate(AnimatorController controller)
        {
            if (!AnimationEvents.IsNullOrEmpty())
                foreach (var animationEvent in AnimationEvents)
                    animationEvent.OnValidate(AllFrames);

            if (controller == null)
                return;

            HashCode = Animator.StringToHash(StateName);

            if (AnimationClip)
                AllFrames = AnimationClip.length * AnimationClip.frameRate;

            if (controller.animationClips.Contains(AnimationClip))
                return;

            ResetProperty();
        }

        private void ResetProperty()
        {
            AnimationClip = null;
            AllFrames = 0;
            HashCode = 0;
        }
    }
}
