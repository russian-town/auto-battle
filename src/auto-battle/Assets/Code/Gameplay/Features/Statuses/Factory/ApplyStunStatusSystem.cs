using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Statuses.Factory
{
    public class ApplyStunStatusSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _statuses;
        private readonly IGroup<GameEntity> _targets;
        private readonly List<GameEntity> _buffer = new(32);

        public ApplyStunStatusSystem(GameContext game)
        {
            _statuses = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Status,
                    GameMatcher.StunStatus,
                    GameMatcher.StatusEffectValue
                    )
                .NoneOf(GameMatcher.Affected));
            
            _targets = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.Mana
                    ));
        }

        public void Execute()
        {
            foreach (var status in _statuses.GetEntities(_buffer))
            foreach (var target in _targets)
            {
                if(status.TargetId != target.Id)
                    continue;

                target.ReplaceMana(target.Mana - status.StatusEffectValue);
                status.isAffected = true;
            }
        }
    }
}
