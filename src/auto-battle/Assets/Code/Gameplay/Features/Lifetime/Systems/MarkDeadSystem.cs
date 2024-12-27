﻿using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Lifetime.Systems
{
    public class MarkDeadSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new(128);

        public MarkDeadSystem(GameContext game)
        {
            _entities = game.GetGroup(
                GameMatcher
                    .AllOf(
                        GameMatcher.CurrentHealth,
                        GameMatcher.MaxHealth)
                    .NoneOf(GameMatcher.Dead));
        }

        public void Execute()
        {
            foreach (var entity in _entities.GetEntities(_buffer))
            {
                if (entity.CurrentHealth <= 0)
                {
                    entity.isDead = true;
                    entity.isProcessingDeath = true;
                }
            }
        }
    }
}