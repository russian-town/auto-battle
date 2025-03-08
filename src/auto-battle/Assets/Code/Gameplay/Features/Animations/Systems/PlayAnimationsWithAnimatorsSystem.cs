using Entitas;

namespace Code.Gameplay.Features.Animations.Systems
{
    public class PlayAnimationsWithAnimatorsSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _animations;
        private readonly IGroup<GameEntity> _animators;

        public PlayAnimationsWithAnimatorsSystem(GameContext game)
        {
            _animations = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.AnimationHash,
                    GameMatcher.NormalizeTime
                ));
            
            _animators = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.FighterAnimator
                ));
        }

        public void Execute()
        {
            foreach (var animation in _animations)
            foreach (var animator in _animators)
            {
                if (animation.ProducerId == animator.Id)
                    animator.FighterAnimator.Play(animation.AnimationHash, animation.NormalizeTime);
            }
        }
    }
}
