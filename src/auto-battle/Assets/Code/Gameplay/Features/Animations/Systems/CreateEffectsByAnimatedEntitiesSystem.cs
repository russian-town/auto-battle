using System.Collections.Generic;
using Code.Common.Entity;
using Code.Gameplay.Features.Effect.Factory;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Animations.Systems
{
    public class CreateEffectsByAnimatedEntitiesSystem : IExecuteSystem
    {
        private readonly IEffectFactory _effectFactory;
        private readonly IGroup<GameEntity> _animated;
        private readonly List<GameEntity> _buffer = new(32);

        public CreateEffectsByAnimatedEntitiesSystem(GameContext game, IEffectFactory effectFactory)
        {
            _effectFactory = effectFactory;
            
            _animated = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.CurrentFrame,
                    GameMatcher.ProducerId,
                    GameMatcher.TargetId,
                    GameMatcher.EventFrame,
                    GameMatcher.EffectSetups
                )
                .NoneOf(GameMatcher.Invoke));
        }

        public void Execute()
        {
            foreach (var animated in _animated.GetEntities(_buffer))
            {
                if (animated.CurrentFrame < animated.EventFrame)
                    continue;

                foreach (var effectSetup in animated.EffectSetups)
                {
                    _effectFactory.CreateEffect(effectSetup, animated.ProducerId, animated.TargetId);
                }

                animated.isInvoke = true;
            }
        }
    }
}
