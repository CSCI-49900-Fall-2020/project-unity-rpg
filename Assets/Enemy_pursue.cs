using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;

public class Enemy_pursue : StateMachineBehaviour
{
    public float speed = 2.5f;
    public float attackRange = 3f;
    public int aggroType = 1;

    Transform player;
    Rigidbody2D rb2d;
    BossController boss;
    public GameObject donut;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        donut = GameObject.Find("Donut");
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        //player = donut.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<PlayerController>().transform;
        rb2d = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<BossController>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Debug.Log(donut.GetComponent<CharacterSwapping>().currentCharacter.name);

        boss.LookAtPlayer();
        player = donut.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<PlayerController>().transform;
        //Vector2 target = new Vector2(player.position.x, rb2d.position.y);
        //Vector2 newPos = Vector2.MoveTowards(rb2d.position, target, speed * Time.fixedDeltaTime);
        //rb2d.MovePosition(newPos);

        if (Vector2.Distance(player.position, rb2d.position) <= attackRange)
        {
            animator.SetTrigger("Attack");
            
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }

    //public void AggroRoutine()
    //{
    //    switch (aggroType)
    //    {
    //        case 1:
    //            //Debug.Log("test");
    //            ChasePlayer();
    //            break;
    //        default:
    //            break;
    //    }
    //}
}
