using Code.Gameplay.Common.Extensions;
using Entitas;

namespace Code.Gameplay.Features.CharacterStats.Systems
{
    public class ApplyDamageFromStats : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _statOwners;

        public ApplyDamageFromStats(GameContext game)
        {
            _statOwners = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.StatsModifiers,
                    GameMatcher.BaseStats,
                    GameMatcher.Damage
                    ));
        }

        public void Execute()
        {
            foreach (var statOwner in _statOwners)
            {
                statOwner.ReplaceDamage(Damage(statOwner).ZeroIfNegative());
            }
        }

        private static float Damage(GameEntity statOwner) =>
            statOwner.BaseStats[Stats.Damage]
            + statOwner.StatsModifiers[Stats.Damage];
    }
}
