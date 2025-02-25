using System.Collections.Generic;
using Code.Common.Entity;
using Code.Gameplay.Features.CharacterStats;
using Entitas;

namespace Code.Gameplay.Features.Statuses.Systems
{
    public class ApplyDodgeStatusSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _statuses;
        private readonly IGroup<GameEntity> _effects;
        private readonly IGroup<GameEntity> _producers;
        private readonly List<GameEntity> _buffer = new(32);

        public ApplyDodgeStatusSystem(GameContext game)
        {
            _statuses = game.GetGroup(
                GameMatcher
                    .AllOf(
                        GameMatcher.Status,
                        GameMatcher.Id,
                        GameMatcher.DodgeStatus,
                        GameMatcher.EffectValue,
                        GameMatcher.ProducerId,
                        GameMatcher.TargetId
                    )
                    .NoneOf(GameMatcher.Affected));
        }

        public void Execute()
        {
            foreach (var status in _statuses.GetEntities(_buffer))
            {
                CreateEntity.Empty($"Change stat {Stats.AttackPower}")
                    .AddStatChange(Stats.AttackPower)
                    .AddEffectValue(status.EffectValue)
                    .AddProducerId(status.ProducerId)
                    .AddTargetId(status.TargetId)
                    .AddApplierStatusLink(status.Id);
                
                status.isAffected = true;
            }
        }
    }
}
