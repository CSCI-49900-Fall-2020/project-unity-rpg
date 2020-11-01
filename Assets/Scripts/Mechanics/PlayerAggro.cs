using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class PlayerAggro : MonoBehaviour
    {
        public float aggroRange;
        public LayerMask enemyLayerMask = 8;
        List<Collider2D> enemiesToAggro = new List<Collider2D>();
        List<Collider2D> oldEnemiesToAggro = new List<Collider2D>();
        public void findEnemies(){
            Collider2D[] entitiesFound = Physics2D.OverlapCircleAll(transform.position, aggroRange, enemyLayerMask);
            enemiesToAggro.Clear();
            
            for(int i = 0; i < entitiesFound.Length; i++){
                if(entitiesFound[i].gameObject.CompareTag("enemy")){
                    Vector3 direction = transform.position - entitiesFound[i].transform.position;
                    RaycastHit2D hit = Physics2D.Raycast(entitiesFound[i].transform.position,direction,aggroRange);
                    Debug.DrawLine(entitiesFound[i].transform.position, hit.point, Color.red);
                    if(hit.collider != null && hit.collider.name == gameObject.name){                
                        enemiesToAggro.Add(entitiesFound[i]); 
                    }
                }
            }
        }

        public void toUpdate(){
            oldEnemiesToAggro = new List<Collider2D>(enemiesToAggro);

            findEnemies();

            foreach(Collider2D oldEnemy in oldEnemiesToAggro)
            {
                if(!enemiesToAggro.Contains(oldEnemy))
                {   
                    Debug.Log(oldEnemy.gameObject.name + " Stopped Chasing");
                    oldEnemy.GetComponent<EnemyAggro>().StopAggro();
                }
            }

            foreach(Collider2D enemy in enemiesToAggro)
            {
                enemy.GetComponent<EnemyAggro>().aggroedPlayer = gameObject.transform;
                enemy.GetComponent<EnemyAggro>().AggroRoutine();
            }
        }

        void OnDrawGizmosSelected() {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, aggroRange);
        }
    }
}