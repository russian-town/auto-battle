using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.AnimationsQueue.Systems
{
    public class CleanupEmptyAnimationsSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _animationsQueue;
        private readonly List<GameEntity> _buffer = new(4);

        public CleanupEmptyAnimationsSystem(GameContext game)
        {
            _animationsQueue = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.AnimationsQueue,
                    GameMatcher.Empty
                ));
        }

        public void Cleanup()
        {
            foreach (var animationsQueue in _animationsQueue.GetEntities(_buffer))
            {
                animationsQueue.Destroy();
            }
        }
    }
}
