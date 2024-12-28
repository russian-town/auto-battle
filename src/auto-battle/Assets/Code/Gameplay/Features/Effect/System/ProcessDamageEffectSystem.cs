using Entitas;

namespace Code.Gameplay.Features.Effect.System
{
    public class ProcessDamageEffectSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _effects;

        public ProcessDamageEffectSystem(GameContext game)
        {
            _effects = game.GetGroup(
                GameMatcher
                    .AllOf(
                        GameMatcher.DamageEffect,
                        GameMatcher.EffectValue,
                        GameMatcher.TargetId
                    ));
        }

        public void Execute()
        {
            foreach (var effect in _effects)
            {
                var target = effect.Target();
                effect.isProcessed = true;
                
                if (target.isDead)
                    continue;

                target.ReplaceCurrentHealth(target.CurrentHealth - effect.EffectValue);
            }
        }
    }
}
