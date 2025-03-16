using System.Collections.Generic;
using Code.Gameplay.Features.Animations.Factory;
using Entitas;

namespace Code.Gameplay.Features.AnimationsQueue.Systems
{
    public class MoveNextAnimationsQueueSystem : IExecuteSystem
    {
        private readonly IAnimationFactory _animationFactory;
        private readonly IGroup<GameEntity> _animationsQueue;
        private readonly List<GameEntity> _buffer = new(4);

        public MoveNextAnimationsQueueSystem(GameContext game, IAnimationFactory animationFactory)
        {
            _animationFactory = animationFactory;
            
            _animationsQueue = game.GetGroup(GameMatcher
                .AllOf(
                GameMatcher.Id,
                GameMatcher.AnimationsQueue,
                GameMatcher.ParentAbilityId,
                GameMatcher.ProducerId,
                GameMatcher.TargetId,
                GameMatcher.MoveNext
                )
                .NoneOf(GameMatcher.Empty));
        }

        public void Execute()
        {
            foreach (var animationsQueue in _animationsQueue.GetEntities(_buffer))
            {
                var setup = animationsQueue.AnimationsQueue.Dequeue();
                
                _animationFactory
                    .CreateAnimation(setup, animationsQueue.ProducerId, animationsQueue.TargetId)
                    .AddQueueLinkedAnimationId(animationsQueue.Id)
                    .AddParentAbilityId(animationsQueue.ParentAbilityId);
                
                animationsQueue.isMoveNext = false;
            }
        }
    }
}
