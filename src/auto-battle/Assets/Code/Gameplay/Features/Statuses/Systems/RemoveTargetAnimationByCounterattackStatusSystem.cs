using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Statuses.Systems
{
    public class RemoveTargetAnimationByCounterattackStatusSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _animation;
        private readonly IGroup<GameEntity> _statuses;
        private readonly List<GameEntity> _buffer = new(32);

        public RemoveTargetAnimationByCounterattackStatusSystem(GameContext game)
        {
            _statuses = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Status,
                    GameMatcher.DamageAbsorption,
                    GameMatcher.CounterattackStatus,
                    GameMatcher.ProducerId
                ));
            
            _animation = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Animation,
                    GameMatcher.DefaultAttackAnimation,
                    GameMatcher.TargetId,
                    GameMatcher.ProducerId
                ));
        }

        public void Execute()
        {
            foreach (var animation in _animation.GetEntities(_buffer))
            foreach (var status in _statuses)
            {
                if (animation.TargetId == status.ProducerId)
                    animation.isAnimationEnded = true;
            }
        }
    }
}
