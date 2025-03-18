using System.Collections.Generic;
using Code.Gameplay.Features.AnimationsQueue.Factory;
using Entitas;

namespace Code.Gameplay.Features.Effect.System
{
    public class CreateAnimationByEffectSystem : IExecuteSystem
    {
        private readonly IAnimationsQueueFactory _animationsQueueFactory;
        private readonly IGroup<GameEntity> _effects;
        private readonly List<GameEntity> _buffer = new(32);

        public CreateAnimationByEffectSystem(GameContext game, IAnimationsQueueFactory animationsQueueFactory)
        {
            _animationsQueueFactory = animationsQueueFactory;
            
            _effects = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Effect,
                    GameMatcher.ProducerId,
                    GameMatcher.TargetId,
                    GameMatcher.AnimationSetups
                    )
                .NoneOf(GameMatcher.Processed));
        }

        public void Execute()
        {
            foreach (var effect in _effects.GetEntities(_buffer))
            {
                    _animationsQueueFactory.CreateAnimationQueue(
                        effect.AnimationSetups,
                        effect.TargetId,
                        effect.ProducerId);
            }
        }
    }
}
