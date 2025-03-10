using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.AnimationsQueue.Systems
{
    public class MarkEmptyAnimationsQueueSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _animationsQueue;
        private readonly List<GameEntity> _buffer = new(4);

        public MarkEmptyAnimationsQueueSystem(GameContext game)
        {
            _animationsQueue = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.AnimationsQueue,
                    GameMatcher.MoveNext
                )
                .NoneOf(GameMatcher.Empty));
        }

        public void Execute()
        {
            foreach (var animationsQueue in _animationsQueue.GetEntities(_buffer))
            {
                if (animationsQueue.AnimationsQueue.Count == 0)
                    animationsQueue.isEmpty = true;
            }
        }
    }
}
