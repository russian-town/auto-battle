using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Effect.System
{
    public class CleanupProcessedEffectsSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _effects;
        private readonly List<GameEntity> _buffer = new(64);

        public CleanupProcessedEffectsSystem(GameContext game)
        {
            _effects = game.GetGroup(
                GameMatcher
                    .AllOf(
                        GameMatcher.Effect,
                        GameMatcher.Processed
                    ));
        }

        public void Cleanup()
        {
            foreach (var effect in _effects.GetEntities(_buffer))
                effect.Destroy();
        }
    }
}
