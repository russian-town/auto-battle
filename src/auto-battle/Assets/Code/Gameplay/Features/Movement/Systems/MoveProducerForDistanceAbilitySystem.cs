using System.Collections.Generic;
using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class MoveProducerForDistanceAbilitySystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _abilities;
        private readonly IGroup<GameEntity> _producers;
        private readonly IGroup<GameEntity> _targets;
        private readonly List<GameEntity> _buffer = new(16);

        public MoveProducerForDistanceAbilitySystem(GameContext game, ITimeService time)
        {
            _time = time;
            
            _abilities = game.GetGroup(GameMatcher
                    .AllOf(
                        GameMatcher.Ability,
                        GameMatcher.ProducerId,
                        GameMatcher.TargetId,
                        GameMatcher.TargetDistance
                    )
                    .NoneOf(GameMatcher.AttackAvailable));
            
            _producers = game.GetGroup(GameMatcher
                    .AllOf(
                        GameMatcher.WorldPosition,
                        GameMatcher.Id
                    ));
            
            _targets = game.GetGroup(GameMatcher
                    .AllOf(
                        GameMatcher.WorldPosition,
                        GameMatcher.Id
                    ));
        }

        public void Execute()
        {
            foreach (var ability in _abilities.GetEntities(_buffer))
            {
                foreach (var producer in _producers)
                foreach (var target in _targets)
                {
                    if (ability.ProducerId != producer.Id)
                        continue;

                    if (ability.TargetId != target.Id)
                        continue;

                    var direction = (target.WorldPosition - producer.WorldPosition).normalized;

                    if (Vector3.Distance(producer.WorldPosition, target.WorldPosition) > ability.TargetDistance)
                    {
                        producer.ReplaceWorldPosition(
                            producer.WorldPosition
                            + direction
                            * producer.Speed
                            * _time.DeltaTime);
                    }
                    else
                    {
                        ability.isAttackAvailable = true;
                    }
                }
            }
        }
    }
}
