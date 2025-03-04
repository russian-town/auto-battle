using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Animations.Systems
{
    public class UpdateAnimationsFramesSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _animations;
        private readonly IGroup<GameEntity> _fighterAnimators;
        private readonly List<GameEntity> _buffer = new(32);

        public UpdateAnimationsFramesSystem(GameContext game)
        {
            _animations = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Animation,
                    GameMatcher.Started,
                    GameMatcher.HashCode,
                    GameMatcher.CurrentFrame,
                    GameMatcher.AllFrames
                    )
                .NoneOf(GameMatcher.Completed));
            
            _fighterAnimators = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.FighterAnimator
                ));
        }

        public void Execute()
        {
            foreach (var animation in _animations.GetEntities(_buffer))
            {
                foreach (var fighterAnimator in _fighterAnimators)
                {
                    if (animation.ProducerId != fighterAnimator.Id)
                        continue;

                    animation.ReplaceCurrentFrame(
                        fighterAnimator.FighterAnimator
                            .GetCurrentFrame(animation.HashCode));

                    if (animation.CurrentFrame >= animation.AllFrames)
                        animation.isCompleted = true;
                }
            }
        }
    }
}
