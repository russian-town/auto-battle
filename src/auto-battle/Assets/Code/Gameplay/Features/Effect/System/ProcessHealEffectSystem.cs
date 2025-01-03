using Entitas;

namespace Code.Gameplay.Features.Effect.System
{
    public class ProcessHealEffectSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _effects;
        private readonly IGroup<GameEntity> _fighters;

        public ProcessHealEffectSystem(GameContext game)
        {
            _effects = game.GetGroup(
                GameMatcher
                    .AllOf(
                        GameMatcher.HealEffect,
                        GameMatcher.EffectValue,
                        GameMatcher.TargetId
                    ));

            _fighters = game.GetGroup(
                GameMatcher
                    .AllOf(
                        GameMatcher.Fighter,
                        GameMatcher.Id));
        }

        public void Execute()
        {
            foreach (var effect in _effects)
            foreach (var fighter in _fighters)
            {
                if (fighter.Id != effect.TargetId)
                    continue;

                effect.isProcessed = true;
                fighter.ReplaceCurrentHealth(fighter.CurrentHealth + effect.EffectValue);
            }
        }
    }
}
