using System.Collections.Generic;
using Code.Gameplay.Features.Effect.Factory;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class CounterattackAbilitySystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IEffectFactory _effectFactory;
        private readonly IGroup<GameEntity> _abilities;
        private readonly List<GameEntity> _buffer = new(24);

        public CounterattackAbilitySystem(GameContext game, IEffectFactory effectFactory)
        {
            _game = game;
            _effectFactory = effectFactory;

            _abilities = game.GetGroup(GameMatcher
                    .AllOf(
                        GameMatcher.CounterattackAbility,
                        GameMatcher.ProducerId,
                        GameMatcher.TargetId
                    )
                    .NoneOf(GameMatcher.Active));
        }

        public void Execute()
        {
            foreach (var ability in _abilities.GetEntities(_buffer))
            foreach (var effectSetup in ability.EffectSetups)
            {
                var producer = _game.GetEntityWithId(ability.ProducerId);
                producer.FighterAnimator.PlayCounterattack();
                _effectFactory.CreateEffect(effectSetup, producer.Damage, ability.ProducerId, ability.TargetId);
                ability.isActive = true;
            }
        }
    }
}
