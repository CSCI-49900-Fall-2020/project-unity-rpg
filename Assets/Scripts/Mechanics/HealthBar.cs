using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer.Mechanics
{
    public class HealthBar : MonoBehaviour
    {
        public Slider slider;
		public Gradient gradient;
		public Image fill;

        public void SetMaxHealth(int maxHealth, int currentHealth)
        {
			slider.maxValue = maxHealth;
			slider.value = currentHealth;

			fill.color = gradient.Evaluate(slider.normalizedValue);
        }

        public void SetCurrentHealth(int currentHealth)
        {
            slider.value = currentHealth;
			fill.color = gradient.Evaluate(slider.normalizedValue);
        }
    }
}
