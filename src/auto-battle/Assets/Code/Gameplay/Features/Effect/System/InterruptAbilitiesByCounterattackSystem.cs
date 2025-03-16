using Entitas;

namespace Code.Gameplay.Features.Effect.System
{
    public class InterruptAbilitiesByCounterattackSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _abilities;
        private readonly IGroup<GameEntity> _effects;

        public InterruptAbilitiesByCounterattackSystem(GameContext game)
        {
            _abilities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Ability,
                    GameMatcher.ProducerId
                    ));
            
            _effects = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Effect,
                    GameMatcher.TargetId,
                    GameMatcher.PushEffect
                    ));
        }

        public void Execute()
        {
            foreach (var effect in _effects)
            foreach (var ability in _abilities)
            {
                if (ability.ProducerId == effect.TargetId)
                    ability.isInterrupted = true;
            }
        }
    }
}
