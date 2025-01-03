﻿using System.Collections.Generic;
using Code.Gameplay.Features.Effect.Factory;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class CounterattackAbilitySystem : IExecuteSystem
    {
        private readonly IEffectFactory _effectFactory;
        private readonly IGroup<GameEntity> _abilities;
        private readonly List<GameEntity> _buffer = new(24);

        public CounterattackAbilitySystem(GameContext game, IEffectFactory effectFactory)
        {
            _effectFactory = effectFactory;

            _abilities = game.GetGroup(
                GameMatcher
                    .AllOf(
                        GameMatcher.Counterattack,
                        GameMatcher.ProducerId,
                        GameMatcher.TargetId,
                        GameMatcher.StatusSetups
                    ));
        }

        public void Execute()
        {
            foreach (var ability in _abilities.GetEntities(_buffer))
            foreach (var effectSetup in ability.EffectSetups)
            {
                _effectFactory.CreateEffect(effectSetup, ability.ProducerId, ability.TargetId);
                ability.isProcessed = true;
            }
        }
    }
}
