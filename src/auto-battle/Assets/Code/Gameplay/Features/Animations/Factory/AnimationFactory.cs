using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Infrastructure.Identifiers;

namespace Code.Gameplay.Features.Animations.Factory
{
    public class AnimationFactory : IAnimationFactory
    {
        private readonly IIdentifierService _identifiers;
        
        public AnimationFactory(IIdentifierService identifiers) => _identifiers = identifiers;
        
        public GameEntity CreateAnimation(int hashCode, float length)
        {
            return CreateEntity.Empty()
                .AddId(_identifiers.Next())
                .AddHashCode(hashCode)
                .AddTimeLeft(length)
                .With(x => x.isAnimation = true);
        }
    }
}
