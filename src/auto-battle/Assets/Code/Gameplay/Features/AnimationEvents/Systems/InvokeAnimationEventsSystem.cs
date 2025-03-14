﻿using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.AnimationEvents.Systems
{
    public class InvokeAnimationEventsSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _animationEvents;
        private readonly IGroup<GameEntity> _linkedAnimations;
        private readonly List<GameEntity> _buffer = new(64);

        public InvokeAnimationEventsSystem(GameContext game)
        {
            _animationEvents = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ProducerId,
                    GameMatcher.TargetFrame
                    )
                .NoneOf(GameMatcher.Invoked));
            
            _linkedAnimations = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ProducerId,
                    GameMatcher.CurrentFrame
                    ));
        }

        public void Execute()
        {
            foreach (var animationEvent in _animationEvents.GetEntities(_buffer))
            foreach (var linkedAnimation in _linkedAnimations)
            {
                if(linkedAnimation.ProducerId != animationEvent.ProducerId)
                    continue;

                if (linkedAnimation.CurrentFrame >= animationEvent.TargetFrame)
                    animationEvent.isInvoked = true;
            }
        }
    }
}
