using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Statuses.Systems
{
    public class UnappliedStatusesWithoutLifetimeSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _statuses;
        private readonly List<GameEntity> _buffer = new(32);

        public UnappliedStatusesWithoutLifetimeSystem(GameContext game)
        {
            _statuses = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Status,
                    GameMatcher.Lifetime
                    )
                .NoneOf(GameMatcher.Unapplied));
        }

        public void Execute()
        {
            foreach (var status in _statuses.GetEntities(_buffer))
            {
                if (status.Lifetime == 0)
                    status.isUnapplied = true;
            }
        }
    }
}
