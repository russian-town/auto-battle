using TMPro;
using UnityEngine;

namespace Code.Gameplay.Features.Effect.Behaviours
{
    public class EffectWindow : MonoBehaviour
    {
        public TMP_Text Text;
        public Color DefaultColor;
        public Color RawDamageColor;
        public Color CriticalDamageColor;

        public void ShowText(float producerMaxDamage, float effectValue)
        {
            Text.color = DefaultColor;
            Text.text = effectValue.ToString("");
        }
    }
}
