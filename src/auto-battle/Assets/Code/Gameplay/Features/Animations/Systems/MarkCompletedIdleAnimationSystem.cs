using Entitas;

namespace Code.Gameplay.Features.Animations.Systems
{
    public class MarkCompletedIdleAnimationSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _animations;

        public MarkCompletedIdleAnimationSystem(GameContext game)
        {
            _animations = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Animation,
                    GameMatcher.Idle,
                    GameMatcher.CooldownUp
                    ));
        }

        public void Execute()
        {
            foreach (var animation in _animations)
            {
                animation.isCompleted = true;
            }
        }
    }
}
