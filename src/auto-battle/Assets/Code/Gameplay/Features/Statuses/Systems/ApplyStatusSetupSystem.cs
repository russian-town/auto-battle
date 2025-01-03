using Entitas;

namespace Code.Gameplay.Features.Statuses.Systems
{
    public class ApplyStatusSetupSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _statuses;

        public ApplyStatusSetupSystem(GameContext game)
        {
            _statuses = game.GetGroup(GameMatcher.AllOf(GameMatcher.Status));
        }

        public void Execute()
        {
            foreach (var status in _statuses)
            {
            }
        }
    }
}
