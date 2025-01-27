using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Fight.Systems
{
    public class ChangeTurnSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _animations;
        private readonly IGroup<GameEntity> _turns;
        private readonly List<GameEntity> _buffer = new(2);

        public ChangeTurnSystem(GameContext game)
        {
            _animations = game.GetGroup(GameMatcher.Animation);
            
            _turns = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Turn)
                .NoneOf(GameMatcher.Changed));
        }

        public void Execute()
        {
            foreach (var turn in _turns.GetEntities(_buffer))
            {
                if (_animations.count == 0)
                {
                    Debug.Log("turn end");
                    turn.isChanged = true;
                }
            }
        }
    }
}
