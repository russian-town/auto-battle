using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Animations.Systems
{
    public class CleanupInterruptedAnimationsLinkedAnimationEventsSystem : ICleanupSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _animations;
        private readonly List<GameEntity> _buffer = new(32);

        public CleanupInterruptedAnimationsLinkedAnimationEventsSystem(GameContext game)
        {
            _game = game;
            
            _animations = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Animation,
                    GameMatcher.Id,
                    GameMatcher.Interrupted
                ));
        }

        public void Cleanup()
        {
            foreach (var animation in _animations.GetEntities(_buffer))
            foreach (var entity in _game.GetEntitiesWithAnimationLinkedId(animation.Id))
            {
                entity.isDestructed = true;
            }
        }
    }
}
