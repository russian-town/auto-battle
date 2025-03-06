using System.Collections.Generic;
using Code.Gameplay.Features.Progress.Factory;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class DefaultAttackAbilitySystem : IExecuteSystem
    {
        private readonly IProgressFactory _progressFactory;
        private readonly IGroup<GameEntity> _abilities;
        private readonly List<GameEntity> _buffer = new(16);

        public DefaultAttackAbilitySystem(
            GameContext game,
            IProgressFactory progressFactory)
        {
            _progressFactory = progressFactory;

            _abilities = game.GetGroup(GameMatcher
                    .AllOf(
                        GameMatcher.DefaultAttackAbility,
                        GameMatcher.Id,
                        GameMatcher.ProducerId,
                        GameMatcher.TargetId,
                        GameMatcher.ProgressQueue
                    )
                    .NoneOf(GameMatcher.Active));
        }

        public void Execute()
        {
            foreach (var ability in _abilities.GetEntities(_buffer))
            {
                if(ability.ProgressQueue.Count == 0)
                    continue;
                
                _progressFactory
                    .CreateProgress(
                        ability.ProgressQueue.Dequeue(),
                        ability.ProducerId,
                        ability.TargetId);

                ability.isActive = true;
            }
        }
    }
}
