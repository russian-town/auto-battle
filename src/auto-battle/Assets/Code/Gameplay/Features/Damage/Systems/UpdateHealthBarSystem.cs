using Entitas;

namespace Code.Gameplay.Features.Damage.Systems
{
    public class UpdateHealthBarSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _healthBars;
        private readonly IGroup<GameEntity> _fighters;

        public UpdateHealthBarSystem(GameContext game)
        {
            _healthBars = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.HealthBar,
                    GameMatcher.TargetId
                    ));
            
            _fighters = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fighter,
                    GameMatcher.Id,
                    GameMatcher.CurrentHealth,
                    GameMatcher.MaxHealth
                    ));
        }

        public void Execute()
        {
            foreach (var healthBar in _healthBars)
            foreach (var fighter in _fighters)
            {
                if (healthBar.TargetId == fighter.Id)
                    healthBar.HealthBar.SetValue(fighter.CurrentHealth, fighter.MaxHealth);
            }
        }
    }
}
