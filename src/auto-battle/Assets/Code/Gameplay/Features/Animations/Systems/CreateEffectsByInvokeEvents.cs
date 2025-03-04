using System.Collections.Generic;
using Code.Gameplay.Features.Effect.Factory;
using Code.Gameplay.Features.Statuses.Factory;
using Entitas;

namespace Code.Gameplay.Features.Animations.Systems
{
    public class CreateEffectsByInvokeEvents : IExecuteSystem
    {
        private readonly IEffectFactory _effectFactory;
        private readonly IGroup<GameEntity> _animationEvents;
        private readonly List<GameEntity> _buffer = new(32);

        public CreateEffectsByInvokeEvents(GameContext game, IEffectFactory effectFactory)
        {
            _effectFactory = effectFactory;

            _animationEvents = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.AnimationEvent,
                    GameMatcher.ProducerId,
                    GameMatcher.TargetId,
                    GameMatcher.EffectSetups,
                    GameMatcher.Invoked
                )
                .NoneOf(GameMatcher.Processed));
        }

        public void Execute()
        {
            foreach (var animationEvent in _animationEvents.GetEntities(_buffer))
            {
                foreach (var effectSetup in animationEvent.EffectSetups)
                    _effectFactory.CreateEffect(effectSetup, animationEvent.ProducerId, animationEvent.TargetId);

                animationEvent.isProcessed = true;
            }
        }
    }
}
