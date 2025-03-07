using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Animations.Systems
{
    public class CompleteAnimationSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _animations;
        private readonly List<GameEntity> _buffer = new(32);

        public CompleteAnimationSystem(GameContext game)
        {
            _animations = game.GetGroup(GameMatcher
                .AllOf(
                GameMatcher.CurrentFrame,
                GameMatcher.LastFrame
                )
                .NoneOf(GameMatcher.Completed));
        }

        public void Execute()
        {
            foreach (var animation in _animations.GetEntities(_buffer))
            {
                if (animation.CurrentFrame >= animation.LastFrame)
                    animation.isCompleted = true;
            }
        }
    }
}
