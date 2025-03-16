using Entitas;

namespace Code.Gameplay.Features.Animations.Systems
{
    public class PlayBlockAnimationSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _blockAnimations;
        private readonly IGroup<GameEntity> _defaultAttackAnimations;

        public PlayBlockAnimationSystem(GameContext game)
        {
            _blockAnimations = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Animation,
                    GameMatcher.Block,
                    GameMatcher.ProducerId,
                    GameMatcher.NormalizeTime
                    ));
            
            _defaultAttackAnimations = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Animation,
                    GameMatcher.DefaultAttack,
                    GameMatcher.TargetId,
                    GameMatcher.NormalizeTime
                    ));
        }

        public void Execute()
        {
            foreach (var blockAnimation in _blockAnimations)
            foreach (var defaultAttackAnimation in _defaultAttackAnimations)
            {
                if (blockAnimation.ProducerId == defaultAttackAnimation.TargetId)
                    blockAnimation.ReplaceNormalizeTime(defaultAttackAnimation.NormalizeTime);

                if (defaultAttackAnimation.NormalizeTime >= 1f)
                    blockAnimation.isCompleted = true;
            }
        }
    }
}
