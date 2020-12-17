using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class Character : MonoBehaviour
    {
        public string characterName;

        public float knockbackResistance;
        public float knockbackStrength = 5.0f;
    }
}