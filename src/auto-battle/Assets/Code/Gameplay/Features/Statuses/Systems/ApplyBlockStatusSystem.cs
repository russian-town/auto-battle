﻿using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.CharacterStats;
using Entitas;

namespace Code.Gameplay.Features.Statuses.Systems
{
    public class ApplyBlockStatusSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _statuses;
        private readonly List<GameEntity> _buffer = new(32);

        public ApplyBlockStatusSystem(GameContext game)
        {
            _game = game;
            
            _statuses = game.GetGroup(
                GameMatcher
                    .AllOf(
                        GameMatcher.Status,
                        GameMatcher.Block,
                        GameMatcher.TargetId,
                        GameMatcher.ProducerId
                    )
                    .NoneOf(GameMatcher.Affected));
        }

        public void Execute()
        {
            foreach (var status in _statuses.GetEntities(_buffer))
            {
                var target = _game.GetEntityWithId(status.TargetId);
                target.isBlocked = true;
                status.isAffected = true;
            }
        }
    }
}