using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class TakeLifeWithLifetimeEntitiesSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _abilities;
        private readonly IGroup<GameEntity> _lifetime;
        private readonly List<GameEntity> _buffer = new(16);

        public TakeLifeWithLifetimeEntitiesSystem(GameContext game)
        {
            _abilities = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Ability,
                GameMatcher.ProducerId,
                GameMatcher.Completed
                ));
            
            _lifetime = game.GetGroup(GameMatcher.Lifetime);
        }

        public void Execute()
        {
            foreach (var ability in _abilities.GetEntities(_buffer))
            foreach (var lifetime in _lifetime)
            {
                if (ability.ProducerId == lifetime.ProducerId)
                    lifetime.ReplaceLifetime(lifetime.Lifetime - 1);

                if (ability.Lifetime <= 0)
                    ability.isDead = true;
                
                ability.isCompleted = false;
            }
        }
    }
}
