using System.Collections.Generic;
using Code.Gameplay.Features.Animations.Configs;
using Code.Gameplay.Features.Animations.Factory;
using Code.Gameplay.Features.Effect.Factory;
using Code.Gameplay.StaticData;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class DefaultAttackAbilitySystem : IExecuteSystem
    {
        private readonly IAnimationFactory _animationFactory;
        private readonly IStaticDataService _staticDataService;
        private readonly IEffectFactory _effectFactory;
        private readonly IGroup<GameEntity> _abilities;
        private readonly List<GameEntity> _buffer = new(32);

        public DefaultAttackAbilitySystem(
            GameContext game,
            IAnimationFactory animationFactory,
            IStaticDataService staticDataService)
        {
            _animationFactory = animationFactory;
            _staticDataService = staticDataService;

            _abilities = game.GetGroup(GameMatcher
                    .AllOf(
                        GameMatcher.DefaultAttack,
                        GameMatcher.ProducerId,
                        GameMatcher.TargetId,
                        GameMatcher.AnimationSetups
                    )
                    .NoneOf(GameMatcher.Active));
        }

        public void Execute()
        {
            foreach (var ability in _abilities.GetEntities(_buffer))
            {
                var config = _staticDataService.GetAbilityConfig(ability.AbilityTypeId);
                
                foreach (var animationSetup in ability.AnimationSetups)
                    _animationFactory
                        .CreateAnimation(animationSetup, ability.ProducerId, ability.TargetId)
                        .AddTargetDistance(config.TargetDistance);

                ability.isActive = true;
            }
        }
    }
}
