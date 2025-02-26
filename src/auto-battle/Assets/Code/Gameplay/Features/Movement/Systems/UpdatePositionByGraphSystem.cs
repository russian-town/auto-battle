using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class UpdatePositionByGraphSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _movements;
        private readonly IGroup<GameEntity> _producers;

        public UpdatePositionByGraphSystem(GameContext game)
        {
            _movements = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Movement,
                    GameMatcher.ProducerId,
                    GameMatcher.TargetId,
                    GameMatcher.AnimationClip,
                    GameMatcher.MoveForwardClip,
                    GameMatcher.MoveBackwardClip,
                    GameMatcher.HorizontalGraph,
                    GameMatcher.VerticalGraph,
                    GameMatcher.TimeLeft
                    )
                .NoneOf(GameMatcher.Reached));
            
            _producers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.WorldPosition,
                    GameMatcher.FighterAnimator
                    ));
        }

        public void Execute()
        {
            foreach (var movement in _movements) 
            foreach (var producer in _producers)
            {
                if(producer.Id != movement.ProducerId)
                    continue;
                
                var position =
                    Vector3.Lerp(
                        producer.WorldPosition,
                        TargetPosition(movement),
                        movement.TimeLeft);

                ChangeClipByDirection(producer, position, movement);
                producer.ReplaceWorldPosition(position);
            }
        }

        private static void ChangeClipByDirection(GameEntity producer, Vector3 position, GameEntity movement)
        {
            if (producer.WorldPosition.x - position.x > 0)
                producer.FighterAnimator.PlayMoveForward();
            else
                producer.FighterAnimator.PlayMoveBackward();
        }

        private static Vector3 TargetPosition(GameEntity movement) =>
            new(
                movement.HorizontalGraph.Evaluate(movement.TimeLeft),
                movement.VerticalGraph.Evaluate(movement.TimeLeft),
                0f);
    }
}
