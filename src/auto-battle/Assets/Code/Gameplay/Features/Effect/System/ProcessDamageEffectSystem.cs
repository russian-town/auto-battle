using Entitas;

namespace Code.Gameplay.Features.Effect.System
{
    public class ProcessDamageEffectSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _effects;

        public ProcessDamageEffectSystem(GameContext game)
        {
            _game = game;
            
            _effects = game.GetGroup(
                GameMatcher
                    .AllOf(
                        GameMatcher.DamageEffect,
                        GameMatcher.EffectValue,
                        GameMatcher.TargetId,
                        GameMatcher.CooldownUp
                    ));
        }

        public void Execute()
        {
            foreach (var effect in _effects)
            {
                var target = _game.GetEntityWithId(effect.TargetId);
                target.ReplaceCurrentHealth(target.CurrentHealth - effect.EffectValue);
                effect.isProcessed = true;
            }
        }
    }
}
