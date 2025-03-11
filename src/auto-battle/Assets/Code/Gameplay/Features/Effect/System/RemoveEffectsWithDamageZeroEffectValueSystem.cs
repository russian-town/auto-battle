using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Effect.System
{
    public class RemoveEffectsWithDamageZeroEffectValueSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _effects;
        private readonly IGroup<GameEntity> _producers;
        private readonly List<GameEntity> _buffer = new(32);

        public RemoveEffectsWithDamageZeroEffectValueSystem(GameContext game)
        {
            _effects = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Effect,
                    GameMatcher.DamageEffect,
                    GameMatcher.ProducerId
                ));
            
            _producers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fighter,
                    GameMatcher.Id,
                    GameMatcher.Damage
                ));
        }

        public void Execute()
        {
            foreach (var producer in _producers)
            foreach (var effect in _effects.GetEntities(_buffer))
            {
                if(effect.ProducerId != producer.Id)
                    continue;

                if (producer.Damage <= 0f)
                    effect.Destroy();
            }
        }
    }
}
