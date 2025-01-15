using Entitas;

namespace Code.Gameplay.Features.Effect.System
{
    public class ProcessHealEffectSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _effects;
        
        public ProcessHealEffectSystem(GameContext game)
        {
            _game = game;
            
            _effects = game.GetGroup(GameMatcher
                    .AllOf(
                        GameMatcher.HealEffect,
                        GameMatcher.EffectValue,
                        GameMatcher.TargetId
                    ));
        }

        public void Execute()
        {
            foreach (var effect in _effects)
            {
                var target = _game.GetEntityWithId(effect.TargetId);
                effect.isProcessed = true;
                target.ReplaceCurrentHealth(target.CurrentHealth + effect.EffectValue);
            }
        }
    }
}
