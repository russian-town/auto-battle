using Code.Gameplay.Features.Statuses.Factory;
using Entitas;

namespace Code.Gameplay.Features.AnimationEvents.Systems
{
    public class CreateStatusesByInvokedEventsSystem : IExecuteSystem
    {
        private readonly IStatusFactory _statusFactory;
        private readonly IGroup<GameEntity> _animationEvents;

        public CreateStatusesByInvokedEventsSystem(GameContext game, IStatusFactory statusFactory)
        {
            _statusFactory = statusFactory;
            
            _animationEvents = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.AnimationEvent,
                    GameMatcher.StatusSetups,
                    GameMatcher.ProducerId,
                    GameMatcher.TargetId,
                    GameMatcher.Invoked
                ));
        }

        public void Execute()
        {
            foreach (var animationEvent in _animationEvents)
            foreach (var statusSetup in animationEvent.StatusSetups)
            {
                _statusFactory.CreateStatus(
                    statusSetup,
                    animationEvent.ProducerId,
                    animationEvent.TargetId);
            }
        }
    }
}
