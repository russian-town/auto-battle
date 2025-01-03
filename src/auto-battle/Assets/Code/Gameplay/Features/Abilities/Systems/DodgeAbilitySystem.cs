﻿using Code.Gameplay.Features.Statuses.Factory;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class DodgeAbilitySystem : IExecuteSystem
    {
        private readonly IStatusFactory _statusFactory;
        private readonly IGroup<GameEntity> _abilities;

        public DodgeAbilitySystem(GameContext game, IStatusFactory statusFactory)
        {
            _statusFactory = statusFactory;

            _abilities = game.GetGroup(
                GameMatcher
                    .AllOf(
                        GameMatcher.Dodge,
                        GameMatcher.ProducerId,
                        GameMatcher.TargetId,
                        GameMatcher.StatusSetups
                    ));
        }

        public void Execute()
        {
            foreach (var ability in _abilities)
            foreach (var statusSetup in ability.StatusSetups)
                _statusFactory.CreateStatus(statusSetup, ability.ProducerId, ability.TargetId);
        }
    }
}