using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Configs
{
    [Serializable]
    public class MovementSetup
    {
        public List<Vector3> TargetPositions;
        public float Speed;
    }
}
