using Entitas;

namespace Code.Gameplay.Features.Animations.Systems
{
    public class SyncAnimationFramesSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _animations;
        private readonly IGroup<GameEntity> _animators;

        public SyncAnimationFramesSystem(GameContext game)
        {
            _animations = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.AnimationHash,
                    GameMatcher.AnimatorId,
                    GameMatcher.CurrentFrame
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
                if (animation.AnimatorId == animator.Id)
                    animation.ReplaceCurrentFrame(animator
                            .FighterAnimator
                            .GetCurrentFrame(animation.AnimationHash));
            }
        }
    }
}
