﻿using Code.Common.Entity;
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
            return CreateEntity.Empty("Animation")
                .AddId(_identifiers.Next())
                .AddAnimationHash(Animator.StringToHash(setup.Name))
                .AddCurrentFrame(0)
                .AddNormalizeTime(0)
                .AddAnimationSpeed(setup.AnimationSpeed)
                .AddLastFrame(setup.LastFrame)
                .With(x => x.isAnimation = true)
                .AddProducerId(producerId)
                .AddTargetId(targetId)
                .With(x => x.AddAnimationEventConfigs(setup.AnimationEventConfigs), when: !setup.AnimationEventConfigs.IsNullOrEmpty());
        }
    }
}
