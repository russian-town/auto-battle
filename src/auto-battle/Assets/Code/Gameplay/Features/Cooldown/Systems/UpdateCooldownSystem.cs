using System.Collections.Generic;
using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.Cooldown.Systems
{
    public class UpdateCooldownSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _cooldawnables;
        private readonly List<GameEntity> _buffer = new(32);

        public UpdateCooldownSystem(GameContext game, ITimeService time)
        {
            _time = time;
            
            _cooldawnables = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Cooldownable,
                    GameMatcher.CooldownLeft
                    )
                .NoneOf(GameMatcher.CooldownUp));
        }

        public void Execute()
        {
            foreach (var cooldawnable in _cooldawnables.GetEntities(_buffer))
            {
                cooldawnable.ReplaceCooldownLeft(cooldawnable.CooldownLeft + _time.DeltaTime);

                if (cooldawnable.CooldownLeft < cooldawnable.Cooldown)
                    continue;

                cooldawnable.RemoveCooldownLeft();
                cooldawnable.isCooldownUp = true;
            }
        }
    }
}
