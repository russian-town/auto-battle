﻿using System.Collections.Generic;
using Code.Gameplay.Features.Animations.Factory;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class GetNextPointByReachedMovementsSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IAnimationFactory _animationFactory;
        private readonly IGroup<GameEntity> _movements;
        private readonly List<GameEntity> _buffer = new(8);

        public GetNextPointByReachedMovementsSystem(GameContext game)
        {
            _game = game;
            
            _movements = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Movement,
                    GameMatcher.ProducerId,
                    GameMatcher.TargetId,
                    GameMatcher.TargetPositions,
                    GameMatcher.Reached
                    )
                .NoneOf(GameMatcher.Active));
        }

        public void Execute()
        {
            foreach (var movement in _movements.GetEntities(_buffer))
            {
                if (movement.TargetPositions.Count == 0)
                    movement.isActive = true;
                else
                {
                    var animator = _game.GetEntityWithId(movement.ProducerId);
                    animator.FighterAnimator.Play(Animator.StringToHash("MoveForward"), 0f, 0f);
                    movement.ReplaceProgress(0f);
                    movement.ReplaceTargetPosition(movement.TargetPositions.Dequeue());
                    movement.isReached = false;
                }
            }
        }
    }
}
