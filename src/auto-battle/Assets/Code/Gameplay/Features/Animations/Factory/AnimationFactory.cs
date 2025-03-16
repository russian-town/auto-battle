using System;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Animations.Configs;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Animations.Factory
{
    public class AnimationFactory : IAnimationFactory
    {
        private readonly IIdentifierService _identifiers;

        public AnimationFactory(IIdentifierService identifiers) => _identifiers = identifiers;

        public GameEntity CreateAnimation(AnimationSetup setup, int producerId, int targetId)
        {
            var animation = CreateEntity.Empty($"{setup.AnimationTypeId} animation")
                .AddId(_identifiers.Next())
                .AddAnimationHash(Animator.StringToHash(setup.Name))
                .AddCurrentFrame(0)
                .AddNormalizeTime(0)
                .AddAnimationSpeed(setup.AnimationSpeed)
                .AddLastFrame(setup.LastFrame)
                .With(x => x.isAnimation = true)
                .AddProducerId(producerId)
                .AddTargetId(targetId)
                .With(x => x.AddAnimationEventConfigs(setup.AnimationEventConfigs), when: !setup.AnimationEventConfigs.IsNullOrEmpty())
                .With(x => x.AddMovementSpeed(setup.MovementSpeed), when: setup.MovementSpeed > 0);

            switch (setup.AnimationTypeId)
            {
                case AnimationTypeId.Idle:
                    return CreateIdleAnimation(animation);
                case AnimationTypeId.Block:
                    return CreateBlockAnimation(animation);
                case AnimationTypeId.DefaultAttack:
                    return CreateDefaultAttackAnimation(animation);
                case AnimationTypeId.Dodge:
                    return CreateDodgeAnimation(animation);
                case AnimationTypeId.Counterattack:
                    return CreateCounterAttackAnimation(animation);
                case AnimationTypeId.DoubleStrike1:
                    return CreateDoubleStrikeAnimation(animation);
                case AnimationTypeId.DoubleStrike2:
                    return CreateDoubleStrikeAnimation(animation);
                case AnimationTypeId.Knockdown:
                    return CreateKnockdownAnimation(animation);
                case AnimationTypeId.Getup:
                    return CreateGetupAnimation(animation);
                case AnimationTypeId.Hit:
                    return CreateHitAnimation(animation);
                case AnimationTypeId.MoveToPosition:
                    return CreateMoveToPositionAnimation(animation);
            }

            throw new Exception($"Animation for type id {setup.AnimationTypeId} not found.");
        }

        private GameEntity CreateIdleAnimation(GameEntity animation)
        {
            return animation
                .With(x => x.isIdle = true)
                .AddCooldown(1f)
                .AddCooldownLeft(0f);
        }

        private GameEntity CreateBlockAnimation(GameEntity animation) =>
            animation.With(x => x.isBlock = true);

        private GameEntity CreateDefaultAttackAnimation(GameEntity animation) =>
            animation.With(x => x.isDefaultAttack = true);

        private GameEntity CreateDodgeAnimation(GameEntity animation) =>
            animation.With(x => x.isDodge = true);

        private GameEntity CreateCounterAttackAnimation(GameEntity animation)
        {
            return animation
                .With(x => x.isCounterattack = true)
                .AddCooldown(.5f)
                .AddCooldownLeft(0f)
                ;
        }

        private GameEntity CreateDoubleStrikeAnimation(GameEntity animation) =>
            animation.With(x => x.isDoubleStrike = true);

        private GameEntity CreateKnockdownAnimation(GameEntity animation) =>
            animation.With(x => x.isKnockdown = true);

        private GameEntity CreateGetupAnimation(GameEntity animation) =>
            animation.With(x => x.isGetup = true);

        private GameEntity CreateHitAnimation(GameEntity animation) =>
            animation.With(x => x.isHit = true);

        private GameEntity CreateMoveToPositionAnimation(GameEntity animation) =>
            animation.With(x => x.isMoveToPosition = true);
    }
}
