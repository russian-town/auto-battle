using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Statuses.Systems
{
    public class ApplyDodgeStatusSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _statuses;
        private readonly IGroup<GameEntity> _effects;
        private readonly IGroup<GameEntity> _producers;
        private readonly List<GameEntity> _buffer = new(32);

        public ApplyDodgeStatusSystem(GameContext game)
        {
            _statuses = game.GetGroup(
                GameMatcher
                    .AllOf(
                        GameMatcher.Status,
                        GameMatcher.DodgeStatus,
                        GameMatcher.ProducerId
                    )
                    .NoneOf(GameMatcher.Affected));
            
            _effects = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Effect,
                    GameMatcher.DamageEffect,
                    GameMatcher.EffectValue,
                    GameMatcher.TargetId
                ));
            
            _producers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fighter,
                    GameMatcher.Id,
                    GameMatcher.FighterAnimator
                ));
        }

        public void Execute()
        {
            foreach (var status in _statuses.GetEntities(_buffer))
            foreach (var effect in _effects)
            {
                if (status.ProducerId != effect.TargetId)
                    continue;
                
                effect.ReplaceEffectValue(0);
                
                foreach (var producer in _producers)
                {
                    if(producer.Id == status.ProducerId)
                        producer.FighterAnimator.PlayDodge();
                }
                
                status.isAffected = true;
            }
        }
    }
}
