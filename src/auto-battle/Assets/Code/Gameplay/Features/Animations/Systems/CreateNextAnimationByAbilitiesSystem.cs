using System.Collections.Generic;
using Code.Gameplay.Features.Animations.Factory;
using Entitas;

namespace Code.Gameplay.Features.Animations.Systems
{
    public class CreateNextAnimationByAbilitiesSystem : IExecuteSystem
    {
        private readonly IAnimationFactory _animationFactory;
        private readonly IGroup<GameEntity> _animations;
        private readonly IGroup<GameEntity> _abilities;
        private readonly List<GameEntity> _buffer = new(16);

        public CreateNextAnimationByAbilitiesSystem(GameContext game, IAnimationFactory animationFactory)
        {
            _animationFactory = animationFactory;
            
            _animations = game.GetGroup(GameMatcher
                    .AllOf(
                        GameMatcher.Animation,
                        GameMatcher.Completed,
                        GameMatcher.ParentAbilityId
                    ));
                
            _abilities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.Active,
                    GameMatcher.AnimationQueue
                    ));
        }

        public void Execute()
        {
            foreach (var ability in _abilities.GetEntities(_buffer))
            foreach (var animation in _animations)
            {
                if(animation.ParentAbilityId != ability.Id)
                    continue;

                if (animation.AnimationQueue.Count == 0)
                {
                    ability.RemoveAnimationQueue();
                    continue;
                }
                
                var setup = ability.AnimationQueue.Dequeue();
                _animationFactory.CreateAnimation(setup, ability.ProducerId, ability.TargetId);
                ability.isActive = false;
            }
        }
    }
}
