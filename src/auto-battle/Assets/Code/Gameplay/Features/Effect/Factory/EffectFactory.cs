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

        public EffectFactory(IIdentifierService identifiers) => _identifiers = identifiers;

        public GameEntity CreateEffect(EffectSetup setup, int producerId, int targetId)
        {
            var effect = CreateEntity.Empty($"{setup.TypeId.ToString()} effect")
                .AddId(_identifiers.Next())
                .With(x => x.isEffect = true)
                .AddEffectValue(setup.Value)
                .AddProducerId(producerId)
                .AddTargetId(targetId)
                ;

            switch (setup.TypeId)
            {
                case EffectTypeId.Damage:
                    return CreateDamage(effect);
                case EffectTypeId.Heal:
                    return CreateHeal(effect);
                case EffectTypeId.Push:
                    return CreatePush(effect);
            }

            throw new Exception($"Effect with type id {setup.TypeId} does not exist.");
        }

        private GameEntity CreateDamage(GameEntity effect) => effect.With(x => x.isDamageEffect = true);

        private GameEntity CreateHeal(GameEntity effect) => effect.With(x => x.isHealEffect = true);
        
        private GameEntity CreatePush(GameEntity effect) => effect.With(x => x.isPushEffect = true);
    }
}
