using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class Knockback : MonoBehaviour
    {
        public bool KnockUpOnly = false;
        public float knockbackStrength = 5.0f;
        public float selfKnockbackResistance = 2f;
        public int knockbackDamage = 5;
        public float selfKnockbackStrength;

        void OnCollisionEnter2D(Collision2D other)
        {
            if(other.gameObject.CompareTag("Player")){
                float knockbackResistance = other.gameObject.GetComponent<Character>().knockbackResistance;
                Vector2 pushDirection = -(gameObject.transform.position - other.gameObject.transform.position).normalized;

                if(KnockUpOnly){
                    pushDirection.x = 0;
                    if(pushDirection.y < 0)
                        pushDirection.y = -pushDirection.y;
                }

                other.gameObject.GetComponent<Rigidbody2D>().AddForce(pushDirection * Mathf.Clamp(knockbackStrength - knockbackResistance,1f,knockbackStrength), ForceMode2D.Impulse);
                other.gameObject.GetComponent<PlayerController>().decrementHealth(knockbackDamage);
            }

            if(other.gameObject.CompareTag("enemy")){
                Vector2 pushDirection = -(gameObject.transform.position - other.gameObject.transform.position).normalized;
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(pushDirection, ForceMode2D.Impulse);
            }
        }

        public void knockbackTarget(GameObject target){
            if(target.CompareTag("Player")){
                float knockbackResistance = target.GetComponent<Character>().knockbackResistance;
                Vector2 pushDirection = -(gameObject.transform.position - target.gameObject.transform.position).normalized;
                target.gameObject.GetComponent<Rigidbody2D>().AddForce(pushDirection * Mathf.Clamp(knockbackStrength - knockbackResistance,0.5f,knockbackStrength), ForceMode2D.Impulse);

            }
        }

        public void knockbackSelf(GameObject fromTarget){
            selfKnockbackStrength = fromTarget.gameObject.GetComponent<Character>().knockbackStrength;
            Vector2 pushDirection = -(fromTarget.gameObject.transform.position - gameObject.transform.position).normalized;
            gameObject.GetComponent<Rigidbody2D>().AddForce(pushDirection * Mathf.Clamp(selfKnockbackStrength - selfKnockbackResistance,0f,knockbackStrength), ForceMode2D.Impulse);
        }
    }
}
