using System;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Buffs.Configs;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;

namespace Code.Gameplay.Features.Buffs.Factory
{
    public class BuffFactory : IBuffFactory
    {
        private readonly IIdentifierService _identifiers;
        private readonly IStaticDataService _staticData;

        public BuffFactory(IIdentifierService identifiers, IStaticDataService staticData)
        {
            _identifiers = identifiers;
            _staticData = staticData;
        }

        public GameEntity CreateBuff(BuffTypeId typeId)
        {
            var config = _staticData.GetBuffConfig(typeId);
            
            switch (typeId)
            {
                case BuffTypeId.Analgesic:
                    return CreateAnalgesic(config);
                case BuffTypeId.Vitamins:
                    return CreateVitamins(config);
            }

            throw new ArgumentException($"Buff for type id {typeId} not found.");
        }

        private GameEntity CreateAnalgesic(BuffConfig config)
        {
            return CreateEntity.Empty()
                    .AddId(_identifiers.Next())
                    .With(x => x.isBuff = true)
                    .With(x => x.isAnalgesic = true)
                ;
        }

        private GameEntity CreateVitamins(BuffConfig config)
        {
            return CreateEntity.Empty()
                    .AddId(_identifiers.Next())
                    .With(x => x.isBuff = true)
                    .With(x => x.isVitamins = true)
                ;
        }
    }
}
