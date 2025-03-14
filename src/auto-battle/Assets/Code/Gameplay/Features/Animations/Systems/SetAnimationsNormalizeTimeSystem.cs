﻿using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Animations.Systems
{
    public class SetAnimationsNormalizeTimeSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _animations;

        public SetAnimationsNormalizeTimeSystem(GameContext game, ITimeService time)
        {
            _time = time;
            
            _animations = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Animation,
                    GameMatcher.AnimationSpeed,
                    GameMatcher.NormalizeTime
                    ));
        }

        public void Execute()
        {
            foreach (var animation in _animations)
                animation.ReplaceNormalizeTime(GetClampedNormalizeTime(animation));
        }

        private float GetClampedNormalizeTime(GameEntity animation) =>
            Mathf.Clamp01(animation.NormalizeTime + _time.DeltaTime * animation.AnimationSpeed);
    }
}
