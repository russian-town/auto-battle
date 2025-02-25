using Entitas;

namespace Code.Gameplay.Features.Fighter.Systems
{
    public class UpdateAnimatorStateInfoByFightersSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _animated;

        public UpdateAnimatorStateInfoByFightersSystem(GameContext game)
        {
            _animated = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.FighterAnimator,
                    GameMatcher.AnimatorStateInfo
                    ));
        }

        public void Execute()
        {
            foreach (var animated in _animated)
            {
                animated.ReplaceAnimatorStateInfo(animated
                    .FighterAnimator
                    .Animator
                    .GetCurrentAnimatorStateInfo(0));
            }
        }
    }
}
