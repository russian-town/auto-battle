using System.Collections.Generic;
using Code.Gameplay.Features.Effect.Configs;
using Code.Gameplay.Features.Effect.Factory;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class DefaultAttackAbilitySystem : IExecuteSystem
    {
        private readonly IEffectFactory _effectFactory;
        private readonly IGroup<GameEntity> _abilities;
        private readonly IGroup<GameEntity> _producers;
        private readonly List<GameEntity> _buffer = new(16);

        public DefaultAttackAbilitySystem(GameContext game, IEffectFactory effectFactory)
        {
            _effectFactory = effectFactory;
            
            _abilities = game.GetGroup(
                GameMatcher
                    .AllOf(
                        GameMatcher.DefaultAttackAbility,
                        GameMatcher.ProducerId,
                        GameMatcher.TargetId,
                        GameMatcher.CooldownUp
                    )
                    .NoneOf(GameMatcher.Active));

            _producers = game.GetGroup(
                GameMatcher
                    .AllOf(
                        GameMatcher.FighterAnimator,
                        GameMatcher.Id,
                        GameMatcher.Damage
                    ));
        }

        public void Execute()
        {
            foreach (var ability in _abilities.GetEntities(_buffer))
            {
                foreach (var producer in _producers)
                {
                    if (producer.Id != ability.ProducerId)
                        continue;

                    producer.FighterAnimator.PlayDefaultAttack();

                    foreach (var effectSetup in ability.EffectSetups)
                        _effectFactory.CreateEffect(effectSetup, ability.ProducerId, ability.TargetId);

                    ability.isActive = true;
                }
            }
        }
    }
}
