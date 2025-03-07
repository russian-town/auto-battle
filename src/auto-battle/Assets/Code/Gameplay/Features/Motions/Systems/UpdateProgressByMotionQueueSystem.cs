using System.Collections.Generic;
using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Motions.Systems
{
    public class UpdateProgressByMotionQueueSystem : IExecuteSystem
    {
        private const float MaxProgress = 1f;
        
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _motions;
        private readonly List<GameEntity> _buffer = new(4);

        public UpdateProgressByMotionQueueSystem(GameContext game, ITimeService time)
        {
            _time = time;
            
            _motions = game.GetGroup(GameMatcher
                .AllOf(
                GameMatcher.Motion,
                GameMatcher.Progress
                )
                .NoneOf(GameMatcher.ProgressFilled));
        }

        public void Execute()
        {
            foreach (var motion in _motions.GetEntities(_buffer))
            {
                motion.ReplaceProgress(Mathf.Clamp01(motion.Progress + _time.DeltaTime * motion.Speed));

                if (motion.Progress >= MaxProgress)
                    motion.isProgressFilled = true;
            }
        }
    }
}
