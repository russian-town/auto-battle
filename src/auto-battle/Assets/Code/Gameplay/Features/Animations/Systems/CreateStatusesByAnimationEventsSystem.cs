using System.Collections.Generic;
using Code.Gameplay.Features.Statuses.Factory;
using Entitas;

namespace Code.Gameplay.Features.Animations.Systems
{
    public class CreateStatusesByAnimationEventsSystem : IExecuteSystem
    {
        private readonly IStatusFactory _statusFactory;
        private readonly IGroup<GameEntity> _animationEvents;
        private readonly List<GameEntity> _buffer = new(32);

        public CreateStatusesByAnimationEventsSystem(GameContext game, IStatusFactory statusFactory)
        {
            _statusFactory = statusFactory;
            
            _animationEvents = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.AnimationHash,
                    GameMatcher.ProducerId,
                    GameMatcher.TargetId,
                    GameMatcher.StatusSetups,
                    GameMatcher.Invoked
                )
                .NoneOf(GameMatcher.Processed));
        }

        public void Execute()
        {
            foreach (var animationEvent in _animationEvents.GetEntities(_buffer))
            {
                foreach (var statusSetup in animationEvent.StatusSetups)
                    _statusFactory.CreateStatus(statusSetup, animationEvent.ProducerId, animationEvent.TargetId);

                animationEvent.isProcessed = true;
            }
        }
    }
}
