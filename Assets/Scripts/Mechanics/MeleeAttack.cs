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

        public Animator attackAnimator;
        public float attackRange = 0.5f;
        public LayerMask enemyLayerMask;
        public int damage;

        void Start()
        {
            attackAnimator = attackPosition.GetComponent<Animator>();
        }
        void Update()
        {
            if(timeBetweenAttack <= 0){
                if(Input.GetKey(KeyCode.G)){
                    attackAnimator.Play("MeleeAttack");
                    Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, enemyLayerMask);

                    for(int i = 0; i < enemiesToDamage.Length; i++){
                        enemiesToDamage[i].GetComponent<EnemyController>().HealthDecrement(damage);
                        enemiesToDamage[i].GetComponent<Knockback>().knockbackSelf(gameObject);
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