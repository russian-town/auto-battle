using Entitas;

namespace Code.Gameplay.Features.Animations.Systems
{
    public class SetCurrentAnimationFrameSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _animated;
        private readonly IGroup<GameEntity> _animators;

        public SetCurrentAnimationFrameSystem(GameContext game)
        {
            _animated = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.HashCode,
                    GameMatcher.ProducerId,
                    GameMatcher.CurrentFrame
                ));
            
            _animators = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.FighterAnimator,
                    GameMatcher.Id
                ));
        }

        public void Execute()
        {
            foreach (var animated in _animated)
            foreach (var animator in _animators)
            {
                if (animated.ProducerId == animator.Id)
                    animated.ReplaceCurrentFrame(animator
                        .FighterAnimator
                        .GetCurrentFrame(animated.HashCode));
            }
        }
    }
}
