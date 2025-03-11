using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.AnimationsQueue.Systems
{
    public class MarkCompletedAbilitiesWithEmptyAnimationsQueueSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _animationsQueue;
        private readonly IGroup<GameEntity> _abilities;
        private readonly List<GameEntity> _buffer = new(16);

        public MarkCompletedAbilitiesWithEmptyAnimationsQueueSystem(GameContext game)
        {
            _animationsQueue = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.AnimationsQueue,
                    GameMatcher.ParentAbilityId,
                    GameMatcher.Empty
                ));
            
            _abilities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Ability,
                    GameMatcher.Id
                ));
        }

        public void Execute()
        {
            foreach (var ability in _abilities.GetEntities(_buffer))
            foreach (var animationsQueue in _animationsQueue)
            {
                if (ability.Id == animationsQueue.ParentAbilityId)
                    ability.isCompleted = true;
            }
        }
    }
}
