using System;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Statuses.Configs;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Statuses.Factory
{
    public class StatusFactory : IStatusFactory
    {
        private readonly IIdentifierService _identifiers;

        public StatusFactory(IIdentifierService identifiers) => _identifiers = identifiers;

        public GameEntity CreateStatus(StatusSetup setup, int producerId, int targetId)
        {
            var status = CreateEntity.Empty()
                .AddId(_identifiers.Next())
                .AddEffectValue(setup.Value)
                .AddProducerId(producerId)
                .AddTargetId(targetId)
                .With(x => x.isStatus = true);

            switch (setup.TypeId)
            {
                case StatusTypeId.Poison:
                    return CreatePoisonStatus(status);
                case StatusTypeId.Stun:
                    return CreateStanStatus(status);
                case StatusTypeId.Dodge:
                    return CreateDodgeStatus(status);
                case StatusTypeId.Block:
                    return CreateBlockStatus(status);
            }
            
            throw new Exception($"Status with type id {setup.TypeId} does not exist.");
        }

        private GameEntity CreateBlockStatus(GameEntity status)
        {
            return status
                    .With(x => x.isBlockStatus = true)
                    .With(x => x.isDamageAbsorption = true)
                ;
        }

        private GameEntity CreateDodgeStatus(GameEntity status)
        {
            return status
                    .With(x => x.isDodgeStatus = true)
                    .With(x => x.isDamageAbsorption = true)
                ;
        }
        
        private GameEntity CreateStanStatus(GameEntity status) =>
            status.With(x => x.isStunStatus = true);
        
        private GameEntity CreatePoisonStatus(GameEntity status) =>
            status.With(x => x.isPoisonStatus = true);
    }
}
