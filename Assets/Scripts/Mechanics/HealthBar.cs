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
<<<<<<< HEAD
        public Text hpNumbers;
=======
>>>>>>> 4214fba... Added a lot of features

        public void SetMaxHealth(int maxHealth, int currentHealth)
        {
			slider.maxValue = maxHealth;
			slider.value = currentHealth;
<<<<<<< HEAD
            hpNumbers.text = currentHealth + " / " + maxHealth;
=======
>>>>>>> 4214fba... Added a lot of features

			fill.color = gradient.Evaluate(slider.normalizedValue);
        }

<<<<<<< HEAD
        public void SetCurrentHealth(int maxHealth, int currentHealth)
        {
            hpNumbers.text = currentHealth + " / " + maxHealth;
=======
        public void SetCurrentHealth(int currentHealth)
        {
>>>>>>> 4214fba... Added a lot of features
            slider.value = currentHealth;
			fill.color = gradient.Evaluate(slider.normalizedValue);
        }
    }
}
