﻿using System.Collections.Generic;
using Code.Gameplay.Features.Animations.Factory;
using Entitas;

namespace Code.Gameplay.Features.Motions.Systems
{
    public class CreateAnimationByMotionsSystem : IExecuteSystem
    {
        private readonly IAnimationFactory _animationFactory;
        private readonly IGroup<GameEntity> _motions;
        private readonly List<GameEntity> _buffer = new(16);

        public CreateAnimationByMotionsSystem(GameContext game, IAnimationFactory animationFactory)
        {
            _animationFactory = animationFactory;

            _motions = game.GetGroup(
                GameMatcher
                    .AllOf(
                        GameMatcher.Motion,
                        GameMatcher.Id,
                        GameMatcher.AnimatorId,
                        GameMatcher.ProducerId,
                        GameMatcher.TargetId,
                        GameMatcher.AnimationSetup
                    )
                    .NoneOf(GameMatcher.Active));
        }

        public void Execute()
        {
            foreach (var motion in _motions.GetEntities(_buffer))
            {
                _animationFactory
                    .CreateAnimation(
                        motion.AnimationSetup,
                        motion.AnimatorId,
                        motion.ProducerId,
                        motion.TargetId)
                    .AddMotionLinkedId(motion.Id)
                    .AddProgress(0);

                motion.isActive = true;
            }
        }
    }
}
