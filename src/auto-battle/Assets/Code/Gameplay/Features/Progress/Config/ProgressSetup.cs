using System;
using Code.Gameplay.Features.Motions.Configs;
using Code.Gameplay.Features.Movement.Config;

namespace Code.Gameplay.Features.Progress.Config
{
    [Serializable]
    public class ProgressSetup
    {
        public float Speed;
        public MotionSetup MotionSetup;
        public MovementSetup MovementSetups;
    }
}
