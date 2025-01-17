using Code.Gameplay.Features.Fighter;
using UnityEngine;

namespace Code.Gameplay.Levels
{
    public class PositionSetup : MonoBehaviour
    {
        public PositionTypeId TypeId;
        public FighterTypeId FighterTypeId;
        
        public Transform Transform => transform;
    }
}
