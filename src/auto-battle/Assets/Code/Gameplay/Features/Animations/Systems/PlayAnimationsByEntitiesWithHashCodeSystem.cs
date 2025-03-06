using Entitas;

namespace Code.Gameplay.Features.Animations.Systems
{
    public class PlayAnimationsByEntitiesWithHashCodeSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _animated;
        private readonly IGroup<GameEntity> _animators;

        public PlayAnimationsByEntitiesWithHashCodeSystem(GameContext game)
        {
            _animated = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.HashCode,
                    GameMatcher.ProducerId,
                    GameMatcher.NormalizedTime
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
                    animator.FighterAnimator.Play(animated.HashCode, animated.NormalizedTime);
            }
        }
    }
}
