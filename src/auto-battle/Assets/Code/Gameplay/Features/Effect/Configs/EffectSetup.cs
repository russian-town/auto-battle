using System;
using UnityEngine;

namespace Code.Gameplay.Features.Effect.Configs
{
    [Serializable] public class EffectSetup
    {
        public EffectTypeId EffectTypeId;
        [Range(0f, 1f)] public float Percent;
    }
}