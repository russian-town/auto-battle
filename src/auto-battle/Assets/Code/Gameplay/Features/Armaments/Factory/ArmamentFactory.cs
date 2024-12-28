using Code.Common.Entity;
using Code.Infrastructure.Identifiers;

namespace Code.Gameplay.Features.Armaments.Factory
{
    public class ArmamentFactory : IArmamentFactory
    {
        private readonly IIdentifierService _identifiers;

        public ArmamentFactory(IIdentifierService identifiers)
        {
            _identifiers = identifiers;
        }

        public GameEntity CreateBlock()
        {
            return CreateEntity.Empty()
                .AddId(_identifiers.Next());
        }
    }
}
