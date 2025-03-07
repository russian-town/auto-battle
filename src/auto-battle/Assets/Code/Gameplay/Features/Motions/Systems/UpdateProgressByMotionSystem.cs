using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.Motions.Systems
{
    public class UpdateProgressByMotionSystem : IExecuteSystem
    {
        private const float MaxProgress = 1f;

        private readonly GameContext _game;
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _motions;
        private readonly List<GameEntity> _buffer = new(4);

        public UpdateProgressByMotionSystem(GameContext game)
        {
            _game = game;

            _motions = game.GetGroup(
                GameMatcher
                    .AllOf(
                        GameMatcher.Motion,
                        GameMatcher.Id,
                        GameMatcher.Progress
                    )
                    .NoneOf(GameMatcher.ProgressFilled));
        }

        public void Execute()
        {
            foreach (var motion in _motions.GetEntities(_buffer))
            {
                var childes = _game.GetEntitiesWithMotionLinkedId(motion.Id);

                motion.ReplaceProgress(GetProgress(childes));

                if (motion.Progress >= MaxProgress)
                    motion.isProgressFilled = true;
            }
        }

        private static float GetProgress(ICollection<GameEntity> childes)
        {
            if (childes.Count == 0)
                return 1;
            
            var progress =
                childes.Count > 1
                    ? childes.Sum(x => x.Progress) / childes.Count
                    : childes.First().Progress;

            return progress;
        }
    }
}
