using System;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Effect.Configs;
using Code.Infrastructure.Identifiers;

namespace Code.Gameplay.Features.Effect.Factory
{
    public class EffectFactory : IEffectFactory
    {
        private readonly IIdentifierService _identifiers;

        public EffectFactory(IIdentifierService identifiers)
        {
            _identifiers = identifiers;
        }

        public GameEntity CreateEffect(EffectSetup setup, int producerId, int targetId)
        {
            switch (setup.EffectTypeId)
            {
                case EffectTypeId.Damage:
                    return CreateDamage(setup.Value, producerId, targetId);
                case EffectTypeId.Heal:
                    return CreateHeal(setup.Value, producerId, targetId);
            }

            throw new Exception($"Effect with type id {setup.EffectTypeId} does not exist.");
        }

        private GameEntity CreateDamage(float value, int producerId, int targetId)
        {
            return CreateEntity.Empty()
                    .AddId(_identifiers.Next())
                    .With(x => x.isEffect = true)
                    .With(x => x.isDamageEffect = true)
                    .AddEffectValue(value)
                    .AddProducerId(producerId)
                    .AddTargetId(targetId)
                ;
        }
        
        private GameEntity CreateHeal(float value, int producerId, int targetId)
        {
            return CreateEntity.Empty()
                    .AddId(_identifiers.Next())
                    .With(x => x.isEffect = true)
                    .With(x => x.isHealEffect = true)
                    .AddEffectValue(value)
                    .AddProducerId(producerId)
                    .AddTargetId(targetId)
                ;
        }
    }
}
