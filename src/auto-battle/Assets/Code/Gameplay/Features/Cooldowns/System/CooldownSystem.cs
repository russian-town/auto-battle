using System.Collections.Generic;
using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.Cooldowns.System
{
    public class CooldownSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _cooldownables;
        private readonly List<GameEntity> _buffer = new(128);

        public CooldownSystem(GameContext game, ITimeService time)
        {
            _time = time;
            _cooldownables = game.GetGroup(GameMatcher.CooldownLeft);
        }

        public void Execute()
        {
            foreach (var cooldownable in _cooldownables.GetEntities(_buffer))
            {
                cooldownable.ReplaceCooldownLeft(cooldownable.CooldownLeft - _time.DeltaTime);

                if (cooldownable.CooldownLeft > 0f)
                    continue;
                
                cooldownable.isCooldownUp = true;
                cooldownable.RemoveCooldownLeft();
            }
        }
    }
}
