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
            switch (setup.TypeId)
            {
                case AnimationTypeId.DefaultAttack:
                    return CreateDefaultAttackAnimation(setup, producerId, targetId);
                case AnimationTypeId.Hit:
                    return CreateHitAnimation(setup, producerId, targetId);
                case AnimationTypeId.DoubleStrike:
                    return CreateDoubleStrikeAnimation(setup, producerId, targetId);
            }

            throw new ArgumentException($"Animation with type id {setup.TypeId} not found.");
        }

        private GameEntity CreateDefaultAttackAnimation(AnimationSetup setup, int producerId, int targetId)
        {
            return CreateEntity.Empty()
                    .AddId(_identifiers.Next())
                    .AddProducerId(producerId)
                    .AddTargetId(targetId)
                    .With(x => x.isAnimation = true)
                    .With(x => x.isDefaultAttackAnimation = true)
                    .AddAnimationCurrentTime(0f)
                    .With(x => x.AddTargetDistance(setup.TargetDistance), when: setup.TargetDistance > 0f)
                ;
        }

        private GameEntity CreateDoubleStrikeAnimation(AnimationSetup setup, int producerId, int targetId)
        {
            return CreateEntity.Empty()
                    .AddId(_identifiers.Next())
                    .AddProducerId(producerId)
                    .AddTargetId(targetId)
                    .With(x => x.isAnimation = true)
                    .With(x => x.isDoubleStrikeAnimation = true)
                    .AddAnimationCurrentTime(0f)
                    .With(x => x.AddTargetDistance(setup.TargetDistance), when: setup.TargetDistance > 0f)
                ;
        }
        
        private GameEntity CreateHitAnimation(AnimationSetup setup, int producerId, int targetId)
        {
            return CreateEntity.Empty()
                    .AddId(_identifiers.Next())
                    .AddProducerId(producerId)
                    .AddTargetId(targetId)
                    .With(x => x.isAnimation = true)
                    .With(x => x.isHitAnimation = true)
                    .AddAnimationCurrentTime(0f)
                    .AddAnimationTime(setup.AnimationTime)
                    .With(x => x.AddTargetDistance(setup.TargetDistance), when: setup.TargetDistance > 0f)
                ;
        }
    }
}
