using System.Collections.Generic;
using Code.Gameplay.Features.Motions.Factory;
using Entitas;

namespace Code.Gameplay.Features.Effect.System
{
    public class CreateMotionByEffectsSystem : IExecuteSystem
    {
        private readonly IMotionsFactory _motionsFactory;
        private readonly IGroup<GameEntity> _effects;
        private readonly List<GameEntity> _buffer = new(32);

        public CreateMotionByEffectsSystem(GameContext game, IMotionsFactory motionsFactory)
        {
            _motionsFactory = motionsFactory;
            
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
                _motionsFactory.CreateMotionQueue(
                    effect.MotionConfigs,
                    effect.TargetId,
                    effect.ProducerId,
                    effect.TargetId);
            }
        }
    }
}
