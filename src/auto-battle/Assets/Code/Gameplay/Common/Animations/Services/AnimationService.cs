using Code.Gameplay.Common.Animations.Registry;

namespace Code.Gameplay.Common.Animations.Services
{
    public class AnimationService : IAnimationService
    {
        private readonly IAnimatorRegistry _animatorRegistry;

        public AnimationService(IAnimatorRegistry animatorRegistry) => _animatorRegistry = animatorRegistry;

        public GameEntity GetEntityWithAnimatorId(int id) => _animatorRegistry.Get<GameEntity>(id);
    }
}
