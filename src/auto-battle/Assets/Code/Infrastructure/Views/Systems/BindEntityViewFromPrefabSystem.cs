﻿using System.Collections.Generic;
using Code.Infrastructure.Views.Factory;
using Entitas;

namespace Code.Infrastructure.Views.Systems
{
    public class BindEntityViewFromPrefabSystem : IExecuteSystem
    {
        private readonly IEntityViewFactory _entityViewFactory;
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new(32);

        public BindEntityViewFromPrefabSystem(GameContext game, IEntityViewFactory entityViewFactory)
        {
            _entityViewFactory = entityViewFactory;
            
            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.ViewPrefab)
                .NoneOf(GameMatcher.View));
        }

        public void Execute()
        {
            foreach (var entity in _entities.GetEntities(_buffer))
                _entityViewFactory.CreateViewForEntityFromPrefab(entity);
        }
    }
}
