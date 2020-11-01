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

        void Start()
        {
            selfRigidBody2D = GetComponent<Rigidbody2D>();
        }

        public void AggroRoutine(){
            switch(aggroType)
            {
                case 1:
                    //Debug.Log("test");
                    ChasePlayer();
                    break;
                default:
                    break;
            }
        }

        public void ChasePlayer(){
            if(aggroedPlayer != null){
                if(transform.position.x < aggroedPlayer.position.x)
                {
                    selfRigidBody2D.velocity = new Vector2(moveSpeed, 0);
                } else {
                    selfRigidBody2D.velocity = new Vector2(-moveSpeed, 0);
                }
            }
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