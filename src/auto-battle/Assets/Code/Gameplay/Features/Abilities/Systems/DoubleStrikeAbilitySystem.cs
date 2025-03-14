﻿using System.Collections.Generic;
using Code.Gameplay.Features.AnimationsQueue.Factory;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class DoubleStrikeAbilitySystem : IExecuteSystem
    {
        private readonly IAnimationsQueueFactory _animationsQueueFactory;
        private readonly IGroup<GameEntity> _abilities;
        private readonly List<GameEntity> _buffer = new(16);

        public DoubleStrikeAbilitySystem(GameContext game, IAnimationsQueueFactory animationsQueueFactory)
        {
            _animationsQueueFactory = animationsQueueFactory;
            
            _abilities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.DoubleStrikeAbility,
                    GameMatcher.AnimationSetups,
                    GameMatcher.Id,
                    GameMatcher.ProducerId,
                    GameMatcher.TargetId,
                    GameMatcher.CooldownUp
                )
                .NoneOf(GameMatcher.Active));
        }

        public void Execute()
        {
            foreach (var ability in _abilities.GetEntities(_buffer))
            {
                _animationsQueueFactory.CreateAnimationQueue(
                    ability.AnimationSetups,
                    ability.ProducerId,
                    ability.TargetId,
                    ability.Id
                    );
                
                ability.isActive = true;
            }
        }
    }
}
