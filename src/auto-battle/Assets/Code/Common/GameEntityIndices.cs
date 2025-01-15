using System.Collections.Generic;
using Code.Gameplay.Features.CharacterStats;
using Code.Gameplay.Features.CharacterStats.Indexing;
using Code.Gameplay.Features.Effect;
using Entitas;
using Zenject;

namespace Code.Common
{
    public class GameEntityIndices : IInitializable
    {
        public const string StatChanges = "StatChanges";

        private readonly GameContext _game;

        public GameEntityIndices(GameContext game) =>
            _game = game;

        public void Initialize()
        {
            _game.AddEntityIndex(
                new EntityIndex<GameEntity, StatKey>(
                    name: StatChanges,
                    _game.GetGroup(
                        GameMatcher.AllOf(
                            GameMatcher.StatChange,
                            GameMatcher.TargetId)),
                    getKey: GetTargetStatKey,
                    new StatKeyEqualityComparer()));
        }

        private static StatKey GetTargetStatKey(GameEntity entity, IComponent component) =>
            new StatKey(
                (component as TargetId)?.Value ?? entity.TargetId,
                (component as StatChange)?.Value ?? entity.StatChange);
    }

    public static class ContextIndicesExtensions
    {
        public static HashSet<GameEntity> TargetStatChanges(this GameContext context, Stats stat, int targetId) =>
            ((EntityIndex<GameEntity, StatKey>)context.GetEntityIndex(GameEntityIndices.StatChanges))
            .GetEntities(new StatKey(targetId, stat));
    }
}
