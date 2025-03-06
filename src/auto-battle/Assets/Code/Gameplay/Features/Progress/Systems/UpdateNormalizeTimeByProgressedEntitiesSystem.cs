using System.Collections.Generic;
using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Progress.Systems
{
    public class UpdateNormalizeTimeByProgressedEntitiesSystem : IExecuteSystem
    {
        private const float MaxNormalizeTime = 1f;
        
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _progressed;
        private readonly List<GameEntity> _buffer = new(32);

        public UpdateNormalizeTimeByProgressedEntitiesSystem(GameContext game, ITimeService time)
        {
            _time = time;
            
            _progressed = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.NormalizedTime,
                    GameMatcher.Speed)
                .NoneOf(GameMatcher.ProgressFilled));
        }

        public void Execute()
        {
            foreach (var progressed in _progressed.GetEntities(_buffer))
            {
                progressed.ReplaceNormalizedTime(GetClampedNormalizeTime(progressed));

                if (progressed.NormalizedTime >= MaxNormalizeTime)
                    progressed.isProgressFilled = true;
            }
        }

        private float GetClampedNormalizeTime(GameEntity progressed) =>
            Mathf.Clamp01(progressed.NormalizedTime + _time.DeltaTime * progressed.Speed);
    }
}
