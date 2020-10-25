using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
    {
    public class MeleeAttack : MonoBehaviour
    {
        public float timeBetweenAttack;
        public float startTimeBetweenAttack;

        public Transform attackPosition;
        public float attackRange;
        public LayerMask enemyLayerMask;
        public int damage;

        // Update is called once per frame
        void Update()
        {
            if(timeBetweenAttack <= 0){
                if(Input.GetKey(KeyCode.G)){
                    Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, enemyLayerMask);

                    for(int i = 0; i < enemiesToDamage.Length; i++){
                        enemiesToDamage[i].GetComponent<Health>().Decrement(damage);
                    }
                    timeBetweenAttack = startTimeBetweenAttack;
                }
            } else {
                timeBetweenAttack -= Time.deltaTime;
            }
        }

        private void OnDrawGizmosSelected() {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPosition.position, attackRange);
        }
    }
}