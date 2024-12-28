using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Features.Abilities.Configs
{
    [CreateAssetMenu(fileName = "AbilityConfig", menuName = "auto-battle/Ability", order = 59)]
    public class AbilityConfig : ScriptableObject
    {
        public AbilityId Id;
        public List<AbilityLevel> Levels;
        public float Cooldown;
    }
}
