using System;
using System.Collections.Generic;
using Code.Gameplay.Features.Animations.Configs;
using UnityEngine;

namespace Code.Gameplay.Features.Effect.Configs
{
    [Serializable]
    public class EffectSetup
    {
        [Range(0f, 1f)] public float EffectValue;
        public EffectTypeId EffectTypeId;
        public List<AnimationSetup> AnimationSetups;

        public void Initialize() => AnimationSetups.ForEach(x => x.Initialize());
    }
}