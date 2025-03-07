using Code.Gameplay.Features.Animations.Configs;
using Code.Gameplay.Features.Movement.Config;
using UnityEngine;

namespace Code.Gameplay.Features.Motions.Configs
{
    [CreateAssetMenu(fileName = "MotionsConfig", menuName = "auto-battle/Motions", order = 59)]
    public class MotionConfig : ScriptableObject
    {
        public AnimationSetup AnimationSetup;
        public MovementConfig MovementConfig;
    }
}
