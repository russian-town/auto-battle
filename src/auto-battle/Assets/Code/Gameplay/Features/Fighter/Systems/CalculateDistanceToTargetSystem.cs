using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Fighter.Systems
{
    public class CalculateDistanceToTargetSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _fighters;

        public CalculateDistanceToTargetSystem(GameContext game)
        {
            _game = game;
            
            _fighters = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fighter,
                    GameMatcher.TargetId,
                    GameMatcher.DistanceToTarget,
                    GameMatcher.WorldPosition
                    ));
        }

        public void Execute()
        {
            foreach (var fighter in _fighters)
            {
                var target = _game.GetEntityWithId(fighter.TargetId);
                var distance = Vector3.Distance(target.WorldPosition, fighter.WorldPosition);
                fighter.ReplaceDistanceToTarget(distance);
            }
        }
    }
}
