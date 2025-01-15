using System.Collections.Generic;
using Code.Gameplay.Features.Statuses.Factory;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class DodgeAbilitySystem : IExecuteSystem
    {
        private readonly IStatusFactory _statusFactory;
        private readonly IGroup<GameEntity> _abilities;
        private readonly List<GameEntity> _buffer = new(32);

        public DodgeAbilitySystem(GameContext game, IStatusFactory statusFactory)
        {
            _statusFactory = statusFactory;

            _abilities = game.GetGroup(
                GameMatcher
                    .AllOf(
                        GameMatcher.Dodge,
                        GameMatcher.ProducerId,
                        GameMatcher.TargetId,
                        GameMatcher.StatusSetups
                    )
                    .NoneOf(GameMatcher.Active));
        }

        public void Execute()
        {
            foreach (var ability in _abilities.GetEntities(_buffer))
            foreach (var statusSetup in ability.StatusSetups)
            {
                _statusFactory.CreateStatus(statusSetup, ability.ProducerId, ability.TargetId);
                ability.isActive = true;
            }
        }
    }
}
