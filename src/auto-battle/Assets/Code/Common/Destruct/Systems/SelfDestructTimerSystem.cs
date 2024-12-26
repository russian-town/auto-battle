using System.Collections.Generic;
using Entitas;
using Unity.VisualScripting;
using UnityEngine;

namespace Code.Common.Destruct.Systems
{
    public class SelfDestructTimerSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new(64);

        public SelfDestructTimerSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher.SelfDestructTimer);
        }

        public void Execute()
        {
            foreach (var entity in _entities.GetEntities(_buffer))
            {
                if (entity.SelfDestructTimer > 0)
                    entity.ReplaceSelfDestructTimer(entity.SelfDestructTimer - Time.deltaTime);
                else
                {
                    entity.RemoveSelfDestructTimer();
                    entity.isDestructed = true;
                }
            }
        }
    }
}
