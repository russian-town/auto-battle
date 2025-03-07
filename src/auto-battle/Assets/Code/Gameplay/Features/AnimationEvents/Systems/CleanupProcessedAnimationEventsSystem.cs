using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.AnimationEvents.Systems
{
    public class CleanupProcessedAnimationEventsSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _animationEvents;
        private readonly List<GameEntity> _buffer = new(64);

        public CleanupProcessedAnimationEventsSystem(GameContext game)
        {
            _animationEvents = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.AnimationEvent,
                    GameMatcher.Processed
                    ));
        }

        public void Cleanup()
        {
            foreach (var animationEvents in _animationEvents.GetEntities(_buffer))
            {
                animationEvents.Destroy();
            }
        }
    }
}
