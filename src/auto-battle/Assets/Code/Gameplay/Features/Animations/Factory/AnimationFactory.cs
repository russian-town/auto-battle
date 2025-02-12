using Code.Common.Entity;
using Code.Infrastructure.Identifiers;

namespace Code.Gameplay.Features.Animations.Factory
{
    public class AnimationFactory : IAnimationFactory
    {
        private readonly IIdentifierService _identifiers;
        
        public AnimationFactory(IIdentifierService identifiers) => _identifiers = identifiers;
        
        public GameEntity CreateAnimation(int hash, float length)
        {
            return CreateEntity.Empty()
                .AddId(_identifiers.Next())
                .AddAnimationHash(hash)
                .AddCurrentTime(0f)
                .AddLength(length);
        }
    }
}
