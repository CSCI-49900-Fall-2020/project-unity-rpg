using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer.Mechanics
{
    public class ManaBar : MonoBehaviour
    {
            public Slider slider;
            public Text mpNumbers;

            public void SetMaxMana(int maxMana, int currentMana)
            {
                slider.maxValue = maxMana;
                slider.value = currentMana;
                mpNumbers.text = currentMana + " / " + maxMana;
            }

            public void SetCurrentHealth(int maxMana, int currentMana)
            {
                mpNumbers.text = currentMana + " / " + maxMana;
                slider.value = currentMana;
            }
    }
}
