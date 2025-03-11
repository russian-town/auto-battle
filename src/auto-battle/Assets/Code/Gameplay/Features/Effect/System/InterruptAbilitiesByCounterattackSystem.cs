using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Effect.System
{
    public class InterruptAbilitiesByCounterattackSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _abilities;
        private readonly IGroup<GameEntity> _effects;
        private readonly List<GameEntity> _buffer = new(16);

        public InterruptAbilitiesByCounterattackSystem(GameContext game)
        {
            _abilities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Ability,
                    GameMatcher.ProducerId
                    )
                .NoneOf(GameMatcher.Completed));
            
            _effects = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Effect,
                    GameMatcher.TargetId,
                    GameMatcher.PushEffect
                    ));
        }

        public void Execute()
        {
            foreach (var ability in _abilities.GetEntities(_buffer))
            foreach (var effect in _effects)
            {
                if (ability.ProducerId == effect.TargetId)
                    ability.isCompleted = true;
            }
        }
    }
}
