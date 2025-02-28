using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Effect.System
{
    public class RemoveBlockedEffectsSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _effects;
        private readonly IGroup<GameEntity> _statuses;
        private readonly IGroup<GameEntity> _producers;
        private readonly List<GameEntity> _buffer = new(32);

        public RemoveBlockedEffectsSystem(GameContext game)
        {
            _effects = game.GetGroup(GameMatcher.Effect);
            
            _statuses = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Status,
                    GameMatcher.BlockStatus
                ));
            
            _producers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.FighterAnimator
                ));
        }

        public void Execute()
        {
            foreach (var effect in _effects.GetEntities(_buffer))
            foreach (var status in _statuses)
            {
                if (status.TargetId != effect.ProducerId)
                    continue;
                
                foreach (var producer in _producers)
                    if(status.ProducerId == producer.Id)
                        producer.FighterAnimator.PlayBlock();
                    
                effect.Destroy();
            }
        }
    }
}
