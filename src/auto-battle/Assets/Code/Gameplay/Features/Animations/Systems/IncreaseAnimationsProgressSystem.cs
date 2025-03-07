using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Animations.Systems
{
    public class IncreaseAnimationsProgressSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _animations;

        public IncreaseAnimationsProgressSystem(GameContext game, ITimeService time)
        {
            _time = time;
            
            _animations = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Animation,
                    GameMatcher.Speed,
                    GameMatcher.Progress
                    ));
        }

        public void Execute()
        {
            foreach (var animation in _animations)
            {
                animation.ReplaceProgress(Mathf.Clamp01(animation.Progress + _time.DeltaTime * animation.Speed));
            }
        }
    }
}
