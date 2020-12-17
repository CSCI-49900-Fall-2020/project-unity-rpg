using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class Knockback : MonoBehaviour
    {
        public float knockbackStrength = 5.0f;
        public float selfKnockbackStrength = 5f;
        public int knockbackDamage = 5;

        void OnCollisionEnter2D(Collision2D other)
        {
            if(other.gameObject.CompareTag("Player")){
                int knockbackResistance = other.gameObject.GetComponent<Character>().knockbackResistance;
                Vector2 pushDirection = -(gameObject.transform.position - other.gameObject.transform.position).normalized;

                other.gameObject.GetComponent<Rigidbody2D>().AddForce(pushDirection * Mathf.Clamp(knockbackStrength - knockbackResistance,0,knockbackStrength), ForceMode2D.Impulse);
                other.gameObject.GetComponent<PlayerController>().decrementHealth(knockbackDamage);
            }

            if(other.gameObject.CompareTag("enemy")){
                Vector2 pushDirection = -(gameObject.transform.position - other.gameObject.transform.position).normalized;
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(pushDirection, ForceMode2D.Impulse);
            }
        }

        public void knockbackTarget(GameObject target){
            if(target.CompareTag("Player")){
                int knockbackResistance = target.GetComponent<Character>().knockbackResistance;
                Vector2 pushDirection = -(gameObject.transform.position - target.gameObject.transform.position).normalized;

                target.gameObject.GetComponent<Rigidbody2D>().AddForce(pushDirection * Mathf.Clamp(knockbackStrength - knockbackResistance,0,knockbackStrength), ForceMode2D.Impulse);
            }
        }

        public void knockbackSelf(GameObject fromTarget){
            Vector2 pushDirection = -(fromTarget.gameObject.transform.position - gameObject.transform.position).normalized;
            gameObject.GetComponent<Rigidbody2D>().AddForce(pushDirection * selfKnockbackStrength, ForceMode2D.Impulse);
            //Debug.Log("Knocking Back Self");
            //gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(5,5), ForceMode2D.Impulse);
        }
    }
}
