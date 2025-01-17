using Code.Gameplay.Features.Fighter;
using UnityEngine;

namespace Code.Gameplay.Levels
{
    public interface ILevelDataProvider
    {
        public Transform UIRoot { get; }
        void RegisterPositionSetup(PositionSetup positionSetup);
        Transform GetTransformByPositionTypeIdFor(FighterTypeId fighterTypeId, PositionTypeId positionTypeId);
        void SetUIRoot(Transform uiRoot);
    }
}
