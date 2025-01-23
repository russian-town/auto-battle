using System;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Statuses.Configs;
using Code.Infrastructure.Identifiers;

namespace Code.Gameplay.Features.Statuses.Factory
{
    public class StatusFactory : IStatusFactory
    {
        private readonly IIdentifierService _identifiers;

        public StatusFactory(IIdentifierService identifiers)
        {
            _identifiers = identifiers;
        }

        public GameEntity CreateStatus(StatusSetup setup, int producerId, int targetId)
        {
            switch (setup.TypeId)
            {
                case StatusTypeId.Poison:
                    break;
                case StatusTypeId.Stun:
                    break;
                case StatusTypeId.Dodge:
                    break;
                case StatusTypeId.Block:
                    return CreateBlockStatus(setup, producerId, targetId);
            }
            
            throw new Exception($"Status with type id {setup.TypeId} does not exist.");
        }

        private GameEntity CreateBlockStatus(StatusSetup setup, int producerId, int targetId)
        {
            return CreateEntity.Empty()
                .AddId(_identifiers.Next())
                .AddStatusTypeId(StatusTypeId.Block)
                .AddEffectValue(setup.Value)
                .AddProducerId(producerId)
                .AddTargetId(targetId)
                .With(x => x.isStatus = true)
                .With(x => x.isBlock = true)
                ;
        }
    }
}
