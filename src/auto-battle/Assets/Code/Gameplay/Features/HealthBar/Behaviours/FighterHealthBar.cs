using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Gameplay.Features.HealthBar.Behaviours
{
    public class FighterHealthBar : MonoBehaviour
    {
        public Image FillImage;
        public TMP_Text CurrentHealthText;
        
        public void UpdateView(float currentHealth, float maxHealth)
        {
            CurrentHealthText.text = currentHealth.ToString("");
            FillImage.fillAmount = currentHealth / maxHealth;
        }
    }
}
