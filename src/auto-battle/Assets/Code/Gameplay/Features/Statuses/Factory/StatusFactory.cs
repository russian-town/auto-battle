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

        public StatusFactory(IIdentifierService identifiers) => _identifiers = identifiers;

        public GameEntity CreateStatus(StatusSetup setup, int producerId, int targetId)
        {
            var status = CreateEntity.Empty($"{setup.TypeId.ToString()} status")
                .AddId(_identifiers.Next())
                .AddEffectValue(setup.Value)
                .AddProducerId(producerId)
                .AddTargetId(targetId)
                .AddLifetime(setup.Lifetime)
                .With(x => x.isStatus = true)
                .With(x => x.isApplied = true);

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

        private GameEntity CreateBlockStatus(GameEntity status) =>
            status.With(x => x.isBlock = true);

        private GameEntity CreateDodgeStatus(GameEntity status) =>
            status.With(x => x.isDodge = true);

        private GameEntity CreateStanStatus(GameEntity status) =>
            status.With(x => x.isStunStatus = true);

        private GameEntity CreatePoisonStatus(GameEntity status) =>
            status.With(x => x.isPoisonStatus = true);
    }
}
