using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Statuses.Systems
{
    public class CleanupUnappliedStatusLinkedChangesSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _statuses;
        private readonly List<GameEntity> _buffer = new(64);
        
        private readonly GameContext _game;

        public CleanupUnappliedStatusLinkedChangesSystem(GameContext game)
        {
            _game = game;
            
            _statuses = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.Status,
                    GameMatcher.Unapplied
                    ));
        }

        public void Cleanup()
        {
            foreach (var status in _statuses.GetEntities(_buffer))
            foreach (var entity in _game.GetEntitiesWithApplierStatusLink(status.Id))
            {
                entity.isDestructed = true;
            }
        }
    }
}
