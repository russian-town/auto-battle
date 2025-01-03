using Code.Gameplay.Features.Statuses.Factory;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class BlockAbilitySystem : IExecuteSystem
    {
        private readonly IStatusFactory _statusFactory;
        private readonly IGroup<GameEntity> _abilities;

        public BlockAbilitySystem(GameContext game, IStatusFactory statusFactory)
        {
            _statusFactory = statusFactory;

            _abilities = game.GetGroup(
                GameMatcher
                    .AllOf(
                        GameMatcher.Block,
                        GameMatcher.ProducerId,
                        GameMatcher.TargetId,
                        GameMatcher.StatusSetups
                    )
                    .NoneOf(GameMatcher.Active));
        }

        public void Execute()
        {
            foreach (var ability in _abilities)
            foreach (var statusSetup in ability.StatusSetups)
            {
                _statusFactory.CreateStatus(statusSetup, ability.ProducerId, ability.TargetId);
                ability.isActive = true;
            }
        }
    }
}
