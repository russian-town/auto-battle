using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Animations.Systems
{
    public class CreateNextAnimationByAbilitiesSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _animations;
        private readonly IGroup<GameEntity> _abilities;
        private readonly List<GameEntity> _buffer = new(16);

        public CreateNextAnimationByAbilitiesSystem(GameContext game)
        {
            _animations = game.GetGroup(GameMatcher
                    .AllOf(
                        GameMatcher.Animation,
                        GameMatcher.Completed,
                        GameMatcher.ParentAbilityId
                    ));
                
            _abilities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.CurrentAnimationIndex,
                    GameMatcher.LastAnimationIndex,
                    GameMatcher.Active
                    ));
        }

        public void Execute()
        {
            foreach (var ability in _abilities.GetEntities(_buffer))
            foreach (var animation in _animations)
            {
                if(animation.ParentAbilityId != ability.Id)
                    continue;
                
                if(ability.CurrentAnimationIndex == ability.LastAnimationIndex - 1)
                    continue;

                ability.ReplaceCurrentAnimationIndex(ability.CurrentAnimationIndex + 1);
                ability.isActive = false;
            }
        }
    }
}
