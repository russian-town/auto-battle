using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class DefaultAttackAbilitySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _abilities;
        private readonly IGroup<GameEntity> _producers;
        private readonly List<GameEntity> _buffer = new(16);

        public DefaultAttackAbilitySystem(GameContext game)
        {
            _abilities = game.GetGroup(
                GameMatcher
                    .AllOf(
                        GameMatcher.DefaultAttackAbility,
                        GameMatcher.ProducerId,
                        GameMatcher.TargetId
                    )
                    .NoneOf(GameMatcher.Active));

            _producers = game.GetGroup(
                GameMatcher
                    .AllOf(
                        GameMatcher.FighterAnimator,
                        GameMatcher.Id
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

                    ability.isActive = true;
                }
            }
        }
    }
}
