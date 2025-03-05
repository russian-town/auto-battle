using System.Collections.Generic;
using Code.Gameplay.Features.Animations.Factory;
using Code.Gameplay.Features.Movement.Factory;
using Code.Gameplay.StaticData;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class DefaultAttackAbilitySystem : IExecuteSystem
    {
        private readonly IStaticDataService _staticData;
        private readonly IMovementFactory _movementFactory;
        private readonly IGroup<GameEntity> _abilities;
        private readonly List<GameEntity> _buffer = new(16);

        public DefaultAttackAbilitySystem(
            GameContext game,
            IStaticDataService staticData,
            IMovementFactory movementFactory)
        {
            _staticData = staticData;
            _movementFactory = movementFactory;

            _abilities = game.GetGroup(GameMatcher
                    .AllOf(
                        GameMatcher.DefaultAttackAbility,
                        GameMatcher.Id,
                        GameMatcher.ProducerId,
                        GameMatcher.TargetId
                    )
                    .NoneOf(GameMatcher.Active));
        }

        public void Execute()
        {
            foreach (var ability in _abilities.GetEntities(_buffer))
            {
                var config = _staticData.GetAbilityConfig(AbilityTypeId.DefaultAttack);
                
                _movementFactory
                    .CreateMovement(config.MovementSetup, ability.ProducerId, ability.TargetId)
                    .AddAnimationSetups(config.AnimationSetups);
                
                ability.isActive = true;
            }
        }
    }
}
