using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Animations.Systems
{
    public class CleanupEventsWithParentAnimationIdSystem : ICleanupSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _animations;
        private readonly List<GameEntity> _buffer = new(64);

        public CleanupEventsWithParentAnimationIdSystem(GameContext game)
        {
            _game = game;
            
            _animations = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Animation,
                    GameMatcher.Id,
                    GameMatcher.AnimationEnded
                ));
        }

        public void Cleanup()
        {
            foreach (var animations in _animations.GetEntities(_buffer))
            foreach (var entity in _game.GetEntitiesWithParentAnimationId(animations.Id))
            {
                entity.isDestructed = true;
            }
        }
    }
}
