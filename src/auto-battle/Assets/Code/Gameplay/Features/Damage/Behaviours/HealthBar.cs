using UnityEngine;
using UnityEngine.UI;

namespace Code.Gameplay.Features.Damage.Behaviours
{
    public class HealthBar : MonoBehaviour
    {
        public Image Fill;

        public void SetValue(float currentHealth, float maxHealth)
        {
            var currentValue = Mathf.Clamp01(currentHealth / maxHealth);
            Fill.fillAmount = currentValue;
        }
    }
}
