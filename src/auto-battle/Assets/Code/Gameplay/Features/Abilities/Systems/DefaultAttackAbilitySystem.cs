using System.Collections.Generic;
using Code.Gameplay.Features.Animations.Factory;
using Code.Gameplay.Features.Movement.Factory;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class DefaultAttackAbilitySystem : IExecuteSystem
    {
        private readonly IAnimationEventFactory _animationEventFactory;
        private readonly IMovementFactory _movementFactory;
        private readonly IGroup<GameEntity> _abilities;
        private readonly IGroup<GameEntity> _producers;
        private readonly List<GameEntity> _buffer = new(16);

        public DefaultAttackAbilitySystem(
            GameContext game,
            IAnimationEventFactory animationEventFactory,
            IMovementFactory movementFactory)
        {
            _animationEventFactory = animationEventFactory;
            _movementFactory = movementFactory;

            _abilities = game.GetGroup(GameMatcher
                    .AllOf(
                        GameMatcher.DefaultAttackAbility,
                        GameMatcher.ProducerId,
                        GameMatcher.TargetId,
                        GameMatcher.AnimationSetups,
                        GameMatcher.MovementSetup
                    )
                    .NoneOf(GameMatcher.Active));
            
            _producers = game.GetGroup(GameMatcher
                    .AllOf(
                        GameMatcher.FighterAnimator,
                        GameMatcher.Id
                    ));
        }

        public void Execute()
        {
            foreach (var ability in _abilities.GetEntities(_buffer))
            {
                /*foreach (var producer in _producers)
                {
                    if (producer.Id != ability.ProducerId)
                        continue;

                    producer.FighterAnimator.PlayDefaultAttack();
                    
                    foreach (var animationSetup in ability.AnimationSetups)
                    foreach (var eventSetup in animationSetup.EventSetups)
                    {
                        _animationEventFactory.CreateAnimation(
                            eventSetup, ability.ProducerId, ability.TargetId, animationSetup.Clip);

                    }*/
                
                _movementFactory.CreateMovement(ability.MovementSetup, ability.ProducerId, ability.TargetId);
                ability.isActive = true;
            }
        }
    }
}
