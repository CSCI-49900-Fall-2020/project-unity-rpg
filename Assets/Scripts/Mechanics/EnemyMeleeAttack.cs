using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;

namespace Platformer.Mechanics
{
    public class EnemyMeleeAttack : MonoBehaviour
    {
        public float timeBetweenAttack;
        public float startTimeBetweenAttack = 5;
        public Transform attackPosition;
        public float attackRange = 3;
        public LayerMask playerLayerMask = 9;
        public int damage = 3;
        // Start is called before the first frame update
        void Start()
        {
            attackPosition = gameObject.GetComponent<EnemyController>().attackPosition.transform;
        }

        public void attackPlayers(){
            if(timeBetweenAttack <= 0){
                Collider2D[] playersToDamage = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, playerLayerMask);

                if(playersToDamage != null){
                    for(int i = 0; i < playersToDamage.Length; i++){
                        playersToDamage[i].GetComponent<PlayerController>().decrementHealth(damage);
                    }

                    timeBetweenAttack = startTimeBetweenAttack;
                }
                
            } else {
                timeBetweenAttack -= Time.deltaTime;
            }
        }
    }
}
