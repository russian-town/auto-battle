using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.AnimationsQueue.Systems
{
    public class MarkProducerTurnCompletedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _animationsQueue;
        private readonly IGroup<GameEntity> _producers;
        private readonly List<GameEntity> _buffer = new(2);

        public MarkProducerTurnCompletedSystem(GameContext game)
        {
            _animationsQueue = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.AnimationsQueue,
                    GameMatcher.ProducerId,
                    GameMatcher.Empty
                ));
            
            _producers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fighter,
                    GameMatcher.Id
                )
                .NoneOf(GameMatcher.TurnCompleted));
        }

        public void Execute()
        {
            foreach (var animationsQueue in _animationsQueue)
            foreach (var producer in _producers.GetEntities(_buffer))
            {
                if (producer.Id == animationsQueue.ProducerId)
                    producer.isTurnCompleted = true;
            }
        }
    }
}
