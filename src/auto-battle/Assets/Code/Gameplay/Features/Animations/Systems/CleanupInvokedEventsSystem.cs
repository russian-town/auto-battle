using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Animations.Systems
{
    public class CleanupInvokedEventsSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _invokedEvents;
        private readonly List<GameEntity> _buffer = new(64);

        public CleanupInvokedEventsSystem(GameContext game)
        {
            _invokedEvents = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Event,
                    GameMatcher.Invoked
                ));
        }

        public void Cleanup()
        {
            foreach (var invokedEvent in _invokedEvents.GetEntities(_buffer))
                invokedEvent.Destroy();
        }
    }
}
