using Entitas;

namespace Code.Gameplay.Features.HealthBar.Systems
{
    public class UpdateHealthByTargetEntitiesSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _healthBars;
        private readonly IGroup<GameEntity> _targets;

        public UpdateHealthByTargetEntitiesSystem(GameContext game)
        {
            _healthBars = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.FighterHealthBar,
                    GameMatcher.TargetId
                    ));
            
            _targets = game.GetGroup(GameMatcher
                    .AllOf(
                        GameMatcher.Id,
                        GameMatcher.CurrentHealth,
                        GameMatcher.MaxHealth
                    ));
        }

        public void Execute()
        {
            foreach (var healthBar in _healthBars)
            foreach (var target in _targets)
            {
                if (healthBar.TargetId == target.Id)
                    healthBar.FighterHealthBar.UpdateView(target.CurrentHealth, target.MaxHealth);
            }
        }
    }
}
