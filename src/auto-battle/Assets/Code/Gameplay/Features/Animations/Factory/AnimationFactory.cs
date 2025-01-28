using System;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Animations.Configs;
using Code.Infrastructure.Identifiers;

namespace Code.Gameplay.Features.Animations.Factory
{
    public class AnimationFactory : IAnimationFactory
    {
        private readonly IIdentifierService _identifiers;

        public AnimationFactory(IIdentifierService identifiers) => _identifiers = identifiers;

        public GameEntity CreateAnimation(AnimationSetup setup, int producerId, int targetId)
        {
            var ability = CreateEntity.Empty()
                .AddId(_identifiers.Next())
                .AddProducerId(producerId)
                .AddTargetId(targetId)
                .AddAnimationCurrentTime(0f)
                .With(x => x.isAnimation = true)
                .With(x => x.AddEventSetups(setup.EventSetups), when: !setup.EventSetups.IsNullOrEmpty())
                ;

            switch (setup.TypeId)
            {
                case AnimationTypeId.DefaultAttack:
                    return CreateDefaultAttackAnimation(ability);
                case AnimationTypeId.Hit:
                    return CreateHitAnimation(ability);
                case AnimationTypeId.DoubleStrike:
                    return CreateDoubleStrikeAnimation(ability);
                case AnimationTypeId.Block:
                    return CreateBlockAnimation(ability);
                case AnimationTypeId.Dodge:
                    return CreateDodgeAnimation(ability);
            }

            throw new ArgumentException($"Animation with type id {setup.TypeId} not found.");
        }

        private GameEntity CreateDefaultAttackAnimation(GameEntity entity) =>
            entity.With(x => x.isDefaultAttackAnimation = true);

        private GameEntity CreateDoubleStrikeAnimation(GameEntity entity) =>
            entity.With(x => x.isDoubleStrikeAnimation = true);

        private GameEntity CreateHitAnimation(GameEntity entity) =>
            entity.With(x => x.isHitAnimation = true);
        
        private GameEntity CreateBlockAnimation(GameEntity entity) =>
            entity.With(x => x.isBlockAnimation = true);
        
        private GameEntity CreateDodgeAnimation(GameEntity entity) =>
            entity.With(x => x.isDodgeAnimation = true);
    }
}
