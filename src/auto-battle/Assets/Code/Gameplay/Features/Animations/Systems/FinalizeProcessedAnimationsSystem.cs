using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Animations.Systems
{
    public class FinalizeProcessedAnimationsSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _animations;
        private readonly List<GameEntity> _buffer = new(32);

        public FinalizeProcessedAnimationsSystem(GameContext game)
        {
            _animations = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Animation,
                    GameMatcher.AnimationEnded
                    ));
        }

        public void Cleanup()
        {
            foreach (var animation in _animations.GetEntities(_buffer))
                animation.Destroy();
        }
    }
}
