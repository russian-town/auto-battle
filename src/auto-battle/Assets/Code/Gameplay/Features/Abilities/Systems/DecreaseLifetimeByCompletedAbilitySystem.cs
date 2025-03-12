﻿using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class DecreaseLifetimeByCompletedAbilitySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _abilities;
        private readonly IGroup<GameEntity> _animations;
        private readonly List<GameEntity> _buffer = new(16);

        public DecreaseLifetimeByCompletedAbilitySystem(GameContext game)
        {
            _abilities = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Ability,
                GameMatcher.Lifetime,
                GameMatcher.Completed
                ));
            
            _animations = game.GetGroup(GameMatcher.Animation);
        }

        public void Execute()
        {
            foreach (var ability in _abilities.GetEntities(_buffer))
            {
                if(_animations.count > 0)
                    continue;
                
                ability.ReplaceLifetime(ability.Lifetime - 1);

                if (ability.Lifetime <= 0)
                    ability.isDead = true;
                
                ability.isCompleted = false;
            }
        }
    }
}
