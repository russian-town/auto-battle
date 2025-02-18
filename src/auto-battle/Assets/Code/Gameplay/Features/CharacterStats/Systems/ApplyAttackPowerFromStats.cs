using Entitas;

namespace Code.Gameplay.Features.CharacterStats.Systems
{
    public class ApplyAttackPowerFromStats : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _statOwners;

        public ApplyAttackPowerFromStats(GameContext game)
        {
            _statOwners = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.StatsModifiers,
                    GameMatcher.BaseStats,
                    GameMatcher.AttackPower
                ));
        }

        public void Execute()
        {
            foreach (var statOwner in _statOwners)
                statOwner.ReplaceAttackPower(AttackPower(statOwner));
        }

        private static float AttackPower(GameEntity statOwner) =>
            statOwner.BaseStats[Stats.AttackPower]
            + statOwner.StatsModifiers[Stats.AttackPower];
    }
}
