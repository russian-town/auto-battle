using System;

namespace Code.Gameplay.Features.Effect.Configs
{
    [Serializable]
    public class EffectSetup
    {
        public EffectTypeId TypeId;
        public float Value;

        public EffectSetup(EffectTypeId typeId, float value)
        {
            TypeId = typeId;
            Value = value;
        }
    }
}