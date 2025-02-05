using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Animations.Systems
{
    public class FinalizeProcessedAnimationsSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _animations;
        private readonly IGroup<GameEntity> _producers;
        private readonly List<GameEntity> _buffer = new(32);

        public FinalizeProcessedAnimationsSystem(GameContext game)
        {
            _animations = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Animation,
                    GameMatcher.ProducerId,
                    GameMatcher.AnimationEnded
                    ));
            
            _producers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.FighterAnimator
                    ));
        }

        public void Cleanup()
        {
            foreach (var animation in _animations.GetEntities(_buffer))
            {
                foreach (var producer in _producers)
                    producer.FighterAnimator.Cleanup();
                
                animation.Destroy();
            }
        }
    }
}
