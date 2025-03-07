using System;
using UnityEngine;

namespace Code.Gameplay.Features.Effect.Configs
{
    [Serializable]
    public class EffectSetup
    {
        [Range(0f, 1f)] public float EffectValue;
        public EffectTypeId EffectTypeId;
    }
}