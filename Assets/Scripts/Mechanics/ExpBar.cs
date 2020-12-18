using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer.Mechanics
{
    public class ExpBar : MonoBehaviour
    {
            public Slider slider;
            public Text expNumbers;

            public void SetExp(int maxExp, int currentExp)
            {
                slider.maxValue = maxExp;
                slider.value = currentExp;
                expNumbers.text = currentExp + " / " + maxExp;
            }

            public void SetCurrentExp(int maxExp, int currentExp)
            {
                expNumbers.text = currentExp + " / " + maxExp;
                slider.value = currentExp;
            }
    }
}
