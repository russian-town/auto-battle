using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Motions.Configs;
using Code.Infrastructure.Identifiers;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class DefaultAttackAbilitySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _abilities;
        private readonly List<GameEntity> _buffer = new(16);
        private readonly IIdentifierService _identifiers;

        public DefaultAttackAbilitySystem(GameContext game, IIdentifierService identifiers)
        {
            _identifiers = identifiers;

            _abilities = game.GetGroup(GameMatcher
                    .AllOf(
                        GameMatcher.DefaultAttackAbility,
                        GameMatcher.Id,
                        GameMatcher.ProducerId,
                        GameMatcher.MotionConfigs,
                        GameMatcher.TargetId
                    )
                    .NoneOf(GameMatcher.Active));
        }

        public void Execute()
        {
            foreach (var ability in _abilities.GetEntities(_buffer))
            {
                CreateEntity.Empty("MotionQueue")
                    .AddId(_identifiers.Next())
                    .AddMotionQueue(new Queue<MotionConfig>(ability.MotionConfigs))
                    .AddAnimatorId(ability.ProducerId)
                    .AddProducerId(ability.ProducerId)
                    .AddTargetId(ability.TargetId)
                    .With(x => x.isMoveNext = true);
                
                ability.isActive = true;
            }
        }
    }
}
