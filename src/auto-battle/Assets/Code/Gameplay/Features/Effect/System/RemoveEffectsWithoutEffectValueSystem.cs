using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Effect.System
{
    public class RemoveEffectsWithoutEffectValueSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _effects;
        private readonly List<GameEntity> _buffer = new(32);

        public RemoveEffectsWithoutEffectValueSystem(GameContext game) =>
            _effects = game.GetGroup(GameMatcher.Effect);

        public void Execute()
        {
            foreach (var effect in _effects.GetEntities(_buffer))
                if (effect.EffectValue == 0f)
                    effect.Destroy();
        }
    }
}
