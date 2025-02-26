using System;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Config
{
    [Serializable]
    public class MovementSetup
    {
        public AnimationCurve HorizontalGraph;
        public AnimationCurve VerticalGraph;
        public AnimationCurve SpeedGraph;
        public AnimationClip MoveForwardClip;
        public AnimationClip MoveBackwardClip;
    }
}
