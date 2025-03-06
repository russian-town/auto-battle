using System.Collections.Generic;
using Code.Gameplay.Features.Statuses.Factory;
using Entitas;

namespace Code.Gameplay.Features.Animations.Systems
{
    public class CreateStatusesByAnimatedEntitiesSystem : IExecuteSystem
    {
        private readonly IStatusFactory _statusFactory;
        private readonly IGroup<GameEntity> _animated;
        private readonly List<GameEntity> _buffer = new(32);

        public CreateStatusesByAnimatedEntitiesSystem(GameContext game, IStatusFactory statusFactory)
        {
            _statusFactory = statusFactory;
            
            _animated = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.CurrentFrame,
                    GameMatcher.ProducerId,
                    GameMatcher.TargetId,
                    GameMatcher.EventFrame,
                    GameMatcher.EffectSetups
                )
                .NoneOf(GameMatcher.Invoke));
        }

        public void Execute()
        {
            foreach (var animated in _animated.GetEntities(_buffer))
            {
                if (animated.CurrentFrame < animated.EventFrame)
                    continue;

                foreach (var statusSetup in animated.StatusSetups)
                    _statusFactory.CreateStatus(statusSetup, animated.ProducerId, animated.TargetId);

                animated.isInvoke = true;
            }
        }
    }
}
