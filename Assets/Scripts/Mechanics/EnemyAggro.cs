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
        public EnemyMeleeAttack meleeAttack;

        void Start()
        {
            selfRigidBody2D = GetComponent<Rigidbody2D>();
            meleeAttack = GetComponent<EnemyMeleeAttack>();
        }

        public void AggroRoutine(){
            switch(aggroType)
            {
                case 1:
                    //Debug.Log("test");
                    ChasePlayer();
                    AttackPlayer();
                    break;
                case 2: // bosses
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
                meleeAttack.attackPlayers();
            }
        }

        public void ChasePlayer(){
            if(aggroedPlayer != null){
                if(transform.position.x < aggroedPlayer.position.x)
                {
                    //selfRigidBody2D.AddForce(new Vector2(moveSpeed,0), ForceMode2D.Force);
                    selfRigidBody2D.velocity = new Vector2(moveSpeed, 0);
                    gameObject.GetComponent<EnemyController>().attackPosition.transform.localPosition = new Vector3(0.25f, 0,0);
                } else {
                    //selfRigidBody2D.AddForce(new Vector2(-moveSpeed,0), ForceMode2D.Force);
                    selfRigidBody2D.velocity = new Vector2(-moveSpeed, 0);
                    gameObject.GetComponent<EnemyController>().attackPosition.transform.localPosition = new Vector3(-0.25f, 0,0);
                }
            }
        }

        public void BossAggro()
        {
            //Debug.Log("hello");
            BossController boss = GetComponent<BossController>();
            boss.bossHealthBar.SetActive(true);


            Vector2 target = new Vector2(aggroedPlayer.position.x, selfRigidBody2D.position.y);
            Vector2 newPos = Vector2.MoveTowards(selfRigidBody2D.position, target, moveSpeed * Time.fixedDeltaTime);
            selfRigidBody2D.MovePosition(newPos);

            //boss.bossHealthBar.SetActive(true);
            //if (!boss.bossHealthBar.activeSelf)
            //if (!boss.bossHealthBar.activeSelf)
            //{
            //    boss.bossHealthBar.SetActive(true);
            //}
        }
        public void BossDeaggro()
        {
            //Debug.Log("hello");
            BossController boss = GetComponent<BossController>();
            boss.bossHealthBar.SetActive(false);
        }

        public void StopAggro(){
            aggroedPlayer = null;
            selfRigidBody2D.velocity = new Vector2(0, 0);
        }
        // Old Aggro Script Applied to Enemeis to Check for Player
        /*
        public float aggroRange;
        
        public Transform eyePosition;

        

        void Update()
        {
            Vector2 endOfLineOfSight = eyePosition.position + Vector3.right * aggroRange;
            RaycastHit2D hitTarget = Physics2D.Raycast(eyePosition.position,endOfLineOfSight,aggroRange);

            if(CanSeePlayer(hitTarget))
            {
                Debug.DrawLine(eyePosition.position, hitTarget.point, Color.red);
            } else {
                Debug.DrawLine(eyePosition.position, endOfLineOfSight, Color.blue);
                selfRigidBody2D.velocity = new Vector2(0,0);
            }
        }

        bool CanSeePlayer(RaycastHit2D hit){
            if(hit.collider != null)
            {
                if(hit.collider.gameObject.CompareTag("Player"))
                {
                    return true;
                } else {
                    return false;
                }
            } 
            
            return false;
            
        }
        */
    }
}