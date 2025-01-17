using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Infrastructure.Identifiers;

namespace Code.Gameplay.Features.Fight.Factory
{
    public class FightFactory : IFightFactory
    {
        private readonly IIdentifierService _identifiers;

        public FightFactory(IIdentifierService identifiers) =>
            _identifiers = identifiers;

        public GameEntity CreateFight(float cooldown, int targetId, int producerId)
        {
            return CreateEntity.Empty()
                .AddId(_identifiers.Next())
                .AddTargetId(targetId)
                .AddProducerId(producerId)
                .AddCooldownLeft(cooldown)
                .With(x => x.isFight = true);
        }
    }
}
