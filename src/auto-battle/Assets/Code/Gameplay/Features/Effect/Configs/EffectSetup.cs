using System;
using UnityEngine;

namespace Code.Gameplay.Features.Effect.Configs
{
    [Serializable]
    public class EffectSetup
    {
        public EffectTypeId EffectTypeId;
        [Range(0f, 1f)] public float Percent;

        public EffectSetup(EffectTypeId effectTypeId, float percent)
        {
            EffectTypeId = effectTypeId;
            Percent = percent;
        }

        public static EffectSetup CreateEffectById(EffectTypeId typeId, float percent) => new(typeId, percent);
    }
}