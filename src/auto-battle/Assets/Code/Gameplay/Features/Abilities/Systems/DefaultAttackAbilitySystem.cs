using System.Collections.Generic;
using Code.Gameplay.Features.Effect;
using Code.Gameplay.Features.Effect.Configs;
using Code.Gameplay.Features.Effect.Factory;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class DefaultAttackAbilitySystem : IExecuteSystem
    {
        private readonly IEffectFactory _effectFactory;
        private readonly IGroup<GameEntity> _abilities;
        private readonly List<GameEntity> _buffer = new(16);

        public DefaultAttackAbilitySystem(GameContext game, IEffectFactory effectFactory)
        {
            _effectFactory = effectFactory;
            
            _abilities = game.GetGroup(GameMatcher
                    .AllOf(
                        GameMatcher.DefaultAttackAbility,
                        GameMatcher.Id,
                        GameMatcher.ProducerId,
                        GameMatcher.TargetId,
                        GameMatcher.EffectValue
                    )
                    .NoneOf(GameMatcher.Active));
        }

        public void Execute()
        {
            foreach (var ability in _abilities.GetEntities(_buffer))
            {
                _effectFactory.CreateEffect(
                    new EffectSetup(EffectTypeId.Damage, ability.EffectValue),
                    ability.ProducerId,
                    ability.TargetId);
                
                ability.isActive = true;
            }
        }
    }
}
