using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Effect.System
{
    public class ProcessPushEffectSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _effects;
        private readonly IGroup<GameEntity> _producers;
        private readonly IGroup<GameEntity> _targets;
        private readonly List<GameEntity> _buffer = new(64);

        public ProcessPushEffectSystem(GameContext game)
        {
            _effects = game.GetGroup(GameMatcher
                    .AllOf(
                        GameMatcher.PushEffect,
                        GameMatcher.EffectValue,
                        GameMatcher.TargetId,
                        GameMatcher.ProducerId
                    )
                    .NoneOf(GameMatcher.Processed));

            _producers = game.GetGroup(GameMatcher
                    .AllOf(
                        GameMatcher.Id,
                        GameMatcher.Damage
                    ));

            _targets = game.GetGroup(GameMatcher
                    .AllOf(
                        GameMatcher.Fighter,
                        GameMatcher.Id,
                        GameMatcher.FighterAnimator,
                        GameMatcher.CurrentHealth
                    ));
        }

        public void Execute()
        {
            foreach (var effect in _effects.GetEntities(_buffer))
            foreach (var producer in _producers)
            {
                if (effect.ProducerId != producer.Id)
                    continue;

                foreach (var target in _targets)
                {
                    if (target.Id != effect.TargetId)
                        continue;

                    target.ReplaceCurrentHealth(
                        target.CurrentHealth - AffectedDamage(producer, effect) * (1 - target.Agility));
                }

                effect.isProcessed = true;
            }
        }

        private static float AffectedDamage(GameEntity producer, GameEntity effect) =>
            producer.Damage * effect.EffectValue;
    }
}
