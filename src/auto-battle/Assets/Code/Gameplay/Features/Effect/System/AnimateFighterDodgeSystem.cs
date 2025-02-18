using Entitas;

namespace Code.Gameplay.Features.Effect.System
{
    public class AnimateFighterDodgeSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _abilities;
        private readonly IGroup<GameEntity> _effects;
        private readonly IGroup<GameEntity> _producers;

        public AnimateFighterDodgeSystem(GameContext game)
        {
            _abilities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Ability,
                    GameMatcher.DodgeAbility,
                    GameMatcher.Active
                ));
            
            _effects = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Effect,
                    GameMatcher.DamageEffect,
                    GameMatcher.EffectValue,
                    GameMatcher.TargetId
                ));
            
            _producers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fighter,
                    GameMatcher.Id,
                    GameMatcher.FighterAnimator
                ));
        }

        public void Execute()
        {
            foreach (var ability in _abilities)
            foreach (var producer in _producers)
            foreach (var effect in _effects)
            {
                if(producer.Id != ability.ProducerId)
                    continue;

                if (producer.Id == effect.TargetId)
                    producer.FighterAnimator.PlayDodge();
            }
        }
    }
}
