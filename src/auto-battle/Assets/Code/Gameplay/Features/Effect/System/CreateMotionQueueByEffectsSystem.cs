using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Motions.Configs;
using Code.Infrastructure.Identifiers;
using Entitas;

namespace Code.Gameplay.Features.Effect.System
{
    public class CreateMotionQueueByEffectsSystem : IExecuteSystem
    {
        private readonly IIdentifierService _identifiers;
        private readonly IGroup<GameEntity> _effects;
        private readonly List<GameEntity> _buffer = new(32);

        public CreateMotionQueueByEffectsSystem(GameContext game, IIdentifierService identifiers)
        {
            _identifiers = identifiers;
            
            _effects = game.GetGroup(GameMatcher
                .AllOf(
                GameMatcher.Effect,
                GameMatcher.MotionConfigs
                )
                .NoneOf(GameMatcher.Processed));
        }

        public void Execute()
        {
            foreach (var effect in _effects.GetEntities(_buffer))
            {
                CreateEntity.Empty("MotionQueue")
                    .AddId(_identifiers.Next())
                    .AddMotionQueue(new Queue<MotionConfig>(effect.MotionConfigs))
                    .AddAnimatorId(effect.TargetId)
                    .AddProducerId(effect.ProducerId)
                    .AddTargetId(effect.TargetId)
                    .With(x => x.isMoveNext = true);
            }
        }
    }
}
