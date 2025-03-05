using System.Collections.Generic;
using Code.Gameplay.Features.Animations.Factory;
using Entitas;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class CreateAnimationByActiveMovementsSystem : IExecuteSystem
    {
        private readonly IAnimationFactory _animationFactory;
        private readonly IGroup<GameEntity> _movements;
        private readonly List<GameEntity> _buffer = new(8);

        public CreateAnimationByActiveMovementsSystem(GameContext game, IAnimationFactory animationFactory)
        {
            _animationFactory = animationFactory;
            
            _movements = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Movement,
                    GameMatcher.Active
                )
                .NoneOf(GameMatcher.Processed));
        }

        public void Execute()
        {
            foreach (var movement in _movements.GetEntities(_buffer))
            {
                foreach (var animationSetup in movement.AnimationSetups)
                    _animationFactory.CreateAnimation(animationSetup, movement.ProducerId, movement.TargetId);

                movement.isProcessed = true;
            }
        }
    }
}
