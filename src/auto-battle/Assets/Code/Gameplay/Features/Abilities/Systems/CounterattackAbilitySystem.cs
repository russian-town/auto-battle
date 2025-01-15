using System.Collections.Generic;
using Code.Gameplay.Features.Effect.Factory;
using Code.Gameplay.Features.Statuses.Factory;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class CounterattackAbilitySystem : IExecuteSystem
    {
        private readonly IEffectFactory _effectFactory;
        private readonly IStatusFactory _statusFactory;
        private readonly IGroup<GameEntity> _abilities;
        private readonly List<GameEntity> _buffer = new(24);
        private readonly IGroup<GameEntity> _defaultAttacks;

        public CounterattackAbilitySystem(GameContext game, IEffectFactory effectFactory, IStatusFactory statusFactory)
        {
            _effectFactory = effectFactory;
            _statusFactory = statusFactory;

            _defaultAttacks = game.GetGroup(
                GameMatcher
                    .AllOf(
                        GameMatcher.DefaultAttack,
                        GameMatcher.TargetId,
                        GameMatcher.ProducerId
                        ));
            
            _abilities = game.GetGroup(
                GameMatcher
                    .AllOf(
                        GameMatcher.Counterattack,
                        GameMatcher.ProducerId,
                        GameMatcher.TargetId,
                        GameMatcher.StatusSetups
                    )
                    .NoneOf(GameMatcher.Active));
        }

        public void Execute()
        {
            foreach (var defaultAttack in _defaultAttacks)
            foreach (var ability in _abilities.GetEntities(_buffer))
            foreach (var statusSetup in ability.StatusSetups)
            foreach (var effectSetup in ability.EffectSetups)
            {
                _statusFactory.CreateStatus(statusSetup, ability.ProducerId, ability.ProducerId);
                _effectFactory.CreateEffect(effectSetup, ability.ProducerId, ability.TargetId);
                ability.isActive = true;
            }
        }
    }
}
