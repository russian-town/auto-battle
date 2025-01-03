using Entitas;

namespace Code.Gameplay.Features.Lifetime.Systems
{
    public class UnapplyStatusesOfDeadTargetsSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _statuses;
        private readonly IGroup<GameEntity> _dead;

        public UnapplyStatusesOfDeadTargetsSystem(GameContext game)
        {
            _statuses = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Status,
                    GameMatcher.TargetId
                    ));           
            
            _dead = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.Dead
                    ));
        }

        public void Execute()
        {
            foreach (var entity in _dead)
            foreach (var status in _statuses)
            {
                if (status.TargetId == entity.Id)
                    status.isUnapplied = true;
            }
        }
    }
}
