using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Animations.Systems
{
    public class CompleteAnimationByAnimatedEntitiesSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _animated;
        private readonly List<GameEntity> _buffer = new(32);

        public CompleteAnimationByAnimatedEntitiesSystem(GameContext game)
        {
            _animated = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.HashCode,
                    GameMatcher.ProducerId,
                    GameMatcher.CurrentFrame,
                    GameMatcher.MaxFrame
                )
                .NoneOf(GameMatcher.Completed));
        }

        public void Execute()
        {
            foreach (var animated in _animated.GetEntities(_buffer))
            {
                if (animated.CurrentFrame >= animated.MaxFrame)
                    animated.isCompleted = true;
            }
        }
    }
}
