using Entitas;

namespace Code.Gameplay.Features.Fighter.Systems
{
    public class UpdateAnimatorClipInfoByFightersSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _animated;

        public UpdateAnimatorClipInfoByFightersSystem(GameContext game)
        {
            _animated = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.FighterAnimator,
                    GameMatcher.AnimatorClipInfo
                ));
        }

        public void Execute()
        {
            foreach (var animated in _animated)
            foreach (var clipInfo in animated.FighterAnimator.Animator.GetCurrentAnimatorClipInfo(0))
            {
                animated.ReplaceAnimatorClipInfo(clipInfo);
            }
        }
    }
}
