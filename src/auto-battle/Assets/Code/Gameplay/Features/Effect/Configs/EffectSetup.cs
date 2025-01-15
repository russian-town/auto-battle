using System;

namespace Code.Gameplay.Features.Effect.Configs
{
    [Serializable]
    public class EffectSetup
    {
        public EffectTypeId EffectTypeId;
        public float Value;
        public float Cooldown;

        public EffectSetup(EffectTypeId effectTypeId, float value, float cooldown)
        {
            EffectTypeId = effectTypeId;
            Value = value;
            Cooldown = cooldown;
        }
    }
}
