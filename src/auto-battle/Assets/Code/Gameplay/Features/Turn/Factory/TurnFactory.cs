using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Infrastructure.Identifiers;

namespace Code.Gameplay.Features.Turn.Factory
{
    public class TurnFactory : ITurnFactory
    {
        private readonly IIdentifierService _identifiers;

        public TurnFactory(IIdentifierService identifiers)
        {
            _identifiers = identifiers;
        }

        public GameEntity CreateTurn(int targetId)
        {
            return CreateEntity.Empty()
                .AddId(_identifiers.Next())
                .AddTargetId(targetId)
                .With(x => x.isTurn = true);
        }
    }
}
