using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Fighter.Systems
{
    public class CalculateDistanceToStartPointSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _fighters;

        public CalculateDistanceToStartPointSystem(GameContext game)
        {
            _fighters = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fighter,
                    GameMatcher.TargetId,
                    GameMatcher.DistanceToStartPoint,
                    GameMatcher.WorldPosition
                ));
        }

        public void Execute()
        {
            foreach (var fighter in _fighters)
                fighter.ReplaceDistanceToStartPoint(Vector3
                    .Distance(
                        fighter.StartPointPosition,
                        fighter.WorldPosition));
        }
    }
}
