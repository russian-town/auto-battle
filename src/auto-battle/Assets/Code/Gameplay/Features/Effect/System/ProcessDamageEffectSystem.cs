using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Effect.System
{
    public class ProcessDamageEffectSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _effects;
        private readonly List<GameEntity> _buffer = new(64);

        public ProcessDamageEffectSystem(GameContext game)
        {
            _game = game;
            
            _effects = game.GetGroup(GameMatcher
                    .AllOf(
                        GameMatcher.DamageEffect,
                        GameMatcher.EffectValue,
                        GameMatcher.TargetId,
                        GameMatcher.ProducerId
                    )
                    .NoneOf(GameMatcher.Processed));
        }

        public void Execute()
        {
            foreach (var effect in _effects.GetEntities(_buffer))
            {
                effect.isProcessed = true;

                if (effect.EffectValue <= 0f)
                    continue;

                var target = _game.GetEntityWithId(effect.TargetId);
                target.FighterAnimator.PlayHit();
                target.ReplaceCurrentHealth(target.CurrentHealth - effect.EffectValue);
            }
        }
    }
}
