using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.AnimationEvents.Systems
{
    public class CleanupInvokedAnimationEventsSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _animationEvents;
        private readonly List<GameEntity> _buffer = new(64);

        public CleanupInvokedAnimationEventsSystem(GameContext game)
        {
            _animationEvents = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.AnimationEvent,
                    GameMatcher.Invoked
                    ));
        }

        public void Cleanup()
        {
            foreach (var animationEvent in _animationEvents.GetEntities(_buffer))
                animationEvent.Destroy();
        }
    }
}
