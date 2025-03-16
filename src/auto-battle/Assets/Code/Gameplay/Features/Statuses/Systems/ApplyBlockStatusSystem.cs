using System.Collections.Generic;
using Code.Common.Entity;
using Code.Gameplay.Features.CharacterStats;
using Entitas;

namespace Code.Gameplay.Features.Statuses.Systems
{
    public class ApplyBlockStatusSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _statuses;
        private readonly IGroup<GameEntity> _targets;
        private readonly List<GameEntity> _buffer = new(24);

        public ApplyBlockStatusSystem(GameContext game)
        {
            _statuses = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Status,
                    GameMatcher.Block,
                    GameMatcher.Id,
                    GameMatcher.ProducerId
                    )
                .NoneOf(GameMatcher.Affected));
            
            _targets = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.Damage
                    ));
        }

        public void Execute()
        {
            foreach (var status in _statuses.GetEntities(_buffer))
            foreach (var target in _targets)
            {
                if (target.Id != status.TargetId)
                    continue;

                CreateEntity.Empty("StatChange")
                    .AddStatChange(Stats.Damage)
                    .AddTargetId(status.TargetId)
                    .AddProducerId(status.ProducerId)
                    .AddEffectValue(-target.Damage)
                    .AddApplierStatusLink(status.Id);

                status.isAffected = true;
            }
        }
    }
}
