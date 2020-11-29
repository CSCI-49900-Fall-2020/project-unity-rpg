using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class Knockback : MonoBehaviour
    {
        public float knockbackStrength = 5.0f;
        public int knockbackDamage = 5;

        void OnCollisionEnter2D(Collision2D other)
        {
            //Debug.Log("Collided");

            if(other.gameObject.CompareTag("Player")){
                //Debug.Log("Player collided with me");

                Vector2 pushDirection = -(gameObject.transform.position - other.gameObject.transform.position).normalized;

                other.gameObject.GetComponent<Rigidbody2D>().AddForce(pushDirection * knockbackStrength, ForceMode2D.Impulse);
                other.gameObject.GetComponent<PlayerController>().decrementHealth(knockbackDamage);
            }

            if(other.gameObject.CompareTag("enemy")){
                Vector2 pushDirection = -(gameObject.transform.position - other.gameObject.transform.position).normalized;
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(pushDirection, ForceMode2D.Impulse);
            }
        }

        public void knockbackTarget(GameObject target){
            if(target.CompareTag("Player")){
                Vector2 pushDirection = -(gameObject.transform.position - target.gameObject.transform.position).normalized;
                target.gameObject.GetComponent<Rigidbody2D>().AddForce(pushDirection * knockbackStrength, ForceMode2D.Impulse);
            }
        }

        public void knockbackSelf(GameObject fromTarget){
            Vector2 pushDirection = -(fromTarget.gameObject.transform.position - gameObject.transform.position).normalized;
            gameObject.GetComponent<Rigidbody2D>().AddForce(pushDirection * knockbackStrength, ForceMode2D.Impulse);
        }
    }
}
