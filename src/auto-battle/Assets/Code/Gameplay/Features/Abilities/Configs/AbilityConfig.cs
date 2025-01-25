using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Features.Animations.Configs;
using UnityEngine;

namespace Code.Gameplay.Features.Abilities.Configs
{
    [CreateAssetMenu(fileName = "AbilityConfig", menuName = "auto-battle/Abilities", order = 59)]
    public class AbilityConfig : ScriptableObject
    {
        [Range(0f, 1f)] public float Chance;
        public AbilityTypeId AbilityTypeId;
        public List<AnimationSetup> AnimationSetups;
        public List<EventSetup> EventSetups;
        public List<AnimationClip> Clips;
        
        public float AnimationTime => Clips.Sum(x => x.length);
    }
}
