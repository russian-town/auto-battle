﻿using UnityEngine;

namespace Code.Gameplay.Features.Movement.Config
{
    [CreateAssetMenu(fileName = "MovementConfig", menuName = "auto-battle/Movements", order = 59)]
    public class MovementConfig : ScriptableObject
    {
        public float Speed;
        public MovementTypeId MovementTypeId;
    }
}
