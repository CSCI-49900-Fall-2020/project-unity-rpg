using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer.Mechanics
{
    public class EnemyHPBar : MonoBehaviour
    {
        public Slider slider;

        private void Awake() {
            slider = GetComponent<Slider>();
        }

        public void SetMaxHealth(int maxHP, int currentHP)
        {
            slider.maxValue = maxHP;
            slider.value = currentHP;
        }

        public void SetCurrentHealth(int currentHP)
        {
            slider.value = currentHP;
        }
    }
}