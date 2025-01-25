using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Effect.System
{
    public class ProcessHealEffectSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _effects;
        private readonly List<GameEntity> _buffer = new(64);

        public ProcessHealEffectSystem(GameContext game)
        {
            _game = game;
            
            _effects = game.GetGroup(GameMatcher
                    .AllOf(
                        GameMatcher.HealEffect,
                        GameMatcher.EffectValue,
                        GameMatcher.TargetId
                    )
                    .NoneOf(GameMatcher.Processed));
        }

        public void Execute()
        {
            foreach (var effect in _effects.GetEntities(_buffer))
            {
                var target = _game.GetEntityWithId(effect.TargetId);
                target.ReplaceCurrentHealth(target.CurrentHealth + effect.EffectValue);
                effect.isProcessed = true;
            }
        }
    }
}
