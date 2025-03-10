using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Animations.Systems
{
    public class MarkMoveNextParentQueueSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _animations;
        private readonly IGroup<GameEntity> _animationsQueue;
        private readonly List<GameEntity> _buffer = new(4);

        public MarkMoveNextParentQueueSystem(GameContext game)
        {
            _animations = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Animation,
                    GameMatcher.QueueLinkedAnimationId,
                    GameMatcher.Completed
                    ));
            
            _animationsQueue = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.AnimationsQueue,
                    GameMatcher.Id
                    )
                .NoneOf(GameMatcher.MoveNext));
        }

        public void Execute()
        {
            foreach (var animationsQueue in _animationsQueue.GetEntities(_buffer))
            foreach (var animation in _animations)
            {
                if (animationsQueue.Id == animation.QueueLinkedAnimationId)
                    animationsQueue.isMoveNext = true;
            }
        }
    }
}
