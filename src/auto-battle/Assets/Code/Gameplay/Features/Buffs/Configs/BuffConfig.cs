using UnityEngine;

namespace Code.Gameplay.Features.Buffs.Configs
{
    [CreateAssetMenu(fileName = "BuffConfig", menuName = "auto-battle/Buffs", order = 59)]
    public class BuffConfig : ScriptableObject
    {
        public float Cooldown;
        public BuffTypeId TypeId;
    }
}
