using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;

namespace Platformer.Mechanics
{
    public class EnemyAggro : MonoBehaviour
    {
        Rigidbody2D selfRigidBody2D;
        public float moveSpeed;
        public int aggroType = 1;
        public Transform aggroedPlayer;
        public float enemyAggroRange = 5;
        //public EnemyMeleeAttack meleeAttack;

        void Start()
        {
            selfRigidBody2D = GetComponent<Rigidbody2D>();
        }

        public void AggroRoutine(){
            switch(aggroType)
            {
                case 1:
                    ChasePlayer();
                    AttackPlayer();
                    break;
                case 2: // bosses;
                    if (Vector2.Distance(gameObject.transform.position, aggroedPlayer.position) <= enemyAggroRange)
                    {
                        BossAggro();
                    }
                    if (Vector2.Distance(gameObject.transform.position, aggroedPlayer.position) > enemyAggroRange)
                    {
                        BossDeaggro();
                    }

                    break;
                default:
                    break;
            }
        }

        public void AttackPlayer(){
            if(aggroedPlayer != null){
                // float distance = Vector2.Distance(gameObject.transform.position,aggroedPlayer.position);
                // if(distance <= meleeAttack.attackRange){
                //     //Debug.Log("Attacking player");
                //     
                // }
                //meleeAttack.attackPlayers();
            }
        }

        public void ChasePlayer(){
            if(aggroedPlayer != null){
                if(transform.position.x < aggroedPlayer.position.x)
                {
                    transform.position += transform.right * (Time.deltaTime * moveSpeed);
                    gameObject.GetComponent<EnemyController>().attackPosition.transform.localPosition = new Vector3(0.25f, 0,0);
                } else {
                    transform.position -= transform.right * (Time.deltaTime * moveSpeed);
                    gameObject.GetComponent<EnemyController>().attackPosition.transform.localPosition = new Vector3(-0.25f, 0,0);
                }
            }
        }

        public void BossAggro()
        {
            BossController boss = GetComponent<BossController>();
            boss.bossHealthBar.SetActive(true);

            Vector2 target = new Vector2(aggroedPlayer.position.x, selfRigidBody2D.position.y);
            Vector2 newPos = Vector2.MoveTowards(selfRigidBody2D.position, target, moveSpeed * Time.fixedDeltaTime);
            selfRigidBody2D.MovePosition(newPos);
        }
        
        public void BossDeaggro()
        {
            BossController boss = GetComponent<BossController>();
            boss.bossHealthBar.SetActive(false);
        }

        public void StopAggro(){
            aggroedPlayer = null;
            selfRigidBody2D.velocity = new Vector2(0, 0);
        }
    }
}