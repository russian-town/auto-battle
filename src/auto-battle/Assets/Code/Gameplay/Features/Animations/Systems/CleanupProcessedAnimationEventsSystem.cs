using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Animations.Systems
{
    public class CleanupProcessedAnimationEventsSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _animationEvents;
        private readonly List<GameEntity> _buffer = new(64);

        public CleanupProcessedAnimationEventsSystem(GameContext game)
        {
            _animationEvents = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.AnimationHash,
                    GameMatcher.Processed
                    ));
        }

        public void Cleanup()
        {
            foreach (var animationEvent in _animationEvents.GetEntities(_buffer))
                animationEvent.Destroy();
        }
    }
}
