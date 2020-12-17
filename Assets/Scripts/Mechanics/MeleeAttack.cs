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
        public float attackRange = 1f;
        public LayerMask enemyLayerMask;
        public int damage;
        GameObject donut;
        SkillTree skillT;
        PlayerController playerController;
        void Start()
        {
            donut = GameObject.Find("Donut");
            skillT = donut.GetComponent<SkillTree>();
            attackAnimator = attackPosition.GetComponent<Animator>();
            playerController = GetComponent<PlayerController>();
        }
        void Update()
        {
            if (timeBetweenAttack <= 0 && playerController.controlEnabled){
                if(Input.GetKey(KeyCode.G)){
                    int bonusDamage = 0;
                    for (int i = 0; i < skillT.sTree.Length; i++)
                    {
                        if (skillT.sTree[i].skilButtonID == "w1" && skillT.sTree[i].abilityLevel >= 1)
                        {
                            bonusDamage += 1 * skillT.sTree[i].abilityLevel;
                        }
                        if (skillT.sTree[i].skilButtonID == "w2" && skillT.sTree[i].abilityLevel >= 1)
                        {
                            bonusDamage += 2 * skillT.sTree[i].abilityLevel;
                        }
                        if (skillT.sTree[i].skilButtonID == "w3" && skillT.sTree[i].abilityLevel >= 1)
                        {
                            bonusDamage += 3 * skillT.sTree[i].abilityLevel;
                        }
                    }

                    attackAnimator.Play("MeleeAttack");

                    Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, enemyLayerMask);

                    for(int i = 0; i < enemiesToDamage.Length; i++){
                        if(enemiesToDamage[i].tag == "enemy"){
                            enemiesToDamage[i].GetComponent<EnemyController>().HealthDecrement(damage + bonusDamage);
                            enemiesToDamage[i].GetComponent<Knockback>().knockbackSelf(gameObject);
                        } else if (enemiesToDamage[i].CompareTag("Boss")){
                            enemiesToDamage[i].GetComponent<BossController>().HealthDecrement(damage + bonusDamage);
                        }
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