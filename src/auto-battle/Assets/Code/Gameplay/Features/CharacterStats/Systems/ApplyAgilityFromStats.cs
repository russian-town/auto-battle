using Code.Gameplay.Common.Extensions;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.CharacterStats.Systems
{
    public class ApplyAgilityFromStats : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _statOwners;

        public ApplyAgilityFromStats(GameContext game)
        {
            _statOwners = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.StatsModifiers,
                    GameMatcher.BaseStats,
                    GameMatcher.Agility
                ));
        }

        public void Execute()
        {
            foreach (var statOwner in _statOwners)
                statOwner.ReplaceAgility(Agility(statOwner).ZeroIfNegative());
        }

        private static float Agility(GameEntity statOwner) =>
            statOwner.BaseStats[Stats.Agility]
                + statOwner.StatsModifiers[Stats.Agility];
    }
}
