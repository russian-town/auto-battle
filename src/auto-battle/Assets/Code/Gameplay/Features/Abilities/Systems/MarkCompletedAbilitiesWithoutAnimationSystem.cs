using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class MarkCompletedAbilitiesWithoutAnimationSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _abilities;
        private readonly IGroup<GameEntity> _animationsQueue;
        private readonly List<GameEntity> _buffer = new(16);

        public MarkCompletedAbilitiesWithoutAnimationSystem(GameContext game)
        {
            _abilities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Ability,
                    GameMatcher.Active
                    )
                .NoneOf(GameMatcher.Completed));
            
            _animationsQueue = game.GetGroup(GameMatcher.AnimationsQueue);
        }

        public void Execute()
        {
            foreach (var ability in _abilities.GetEntities(_buffer))
            {
                if (_animationsQueue.count == 0)
                    ability.isCompleted = true;
            }
        }
    }
}
