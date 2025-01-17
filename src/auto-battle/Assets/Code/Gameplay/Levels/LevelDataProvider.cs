using System;
using System.Collections.Generic;
using Code.Gameplay.Features.Fighter;
using UnityEngine;

namespace Code.Gameplay.Levels
{
    public class LevelDataProvider : ILevelDataProvider
    {
        private readonly Dictionary<PositionTypeId, Transform> _getTransformByPositionIdForHero = new();
        private readonly Dictionary<PositionTypeId, Transform> _getTransformByPositionIdForEnemy = new();

        public Transform UIRoot { get; private set; }

        public void SetUIRoot(Transform uiRoot) => UIRoot = uiRoot;
        
        public void RegisterPositionSetup(PositionSetup positionSetup)
        {
            switch (positionSetup.FighterTypeId)
            {
                case FighterTypeId.Hero:
                    _getTransformByPositionIdForHero.Add(positionSetup.TypeId, positionSetup.Transform);
                    break;
                case FighterTypeId.Enemy:
                    _getTransformByPositionIdForEnemy.Add(positionSetup.TypeId, positionSetup.Transform);
                    break;
            }
        }
        
        public Transform GetTransformByPositionTypeIdFor(FighterTypeId fighterTypeId, PositionTypeId positionTypeId)
        {
            switch (fighterTypeId)
            {
                case FighterTypeId.Hero:
                    return GetTransformByPositionTypeIdForHero(positionTypeId);
                case FighterTypeId.Enemy:
                    return GetTransformByPositionTypeIdForEnemy(positionTypeId);
            }
            
            throw new ArgumentException($"Dictionary for fighter type id {fighterTypeId} not found.");
        }

        private Transform GetTransformByPositionTypeIdForHero(PositionTypeId typeId)
        {
            if (_getTransformByPositionIdForHero.TryGetValue(typeId, out var value))
                return value;

            throw new ArgumentException($"Transform for hero of type id {typeId} not found.");
        }
        
        private Transform GetTransformByPositionTypeIdForEnemy(PositionTypeId typeId)
        {
            if (_getTransformByPositionIdForEnemy.TryGetValue(typeId, out var value))
                return value;

            throw new ArgumentException($"Transform for enemy of type id {typeId} not found.");
        }
    }
}
