using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Chase : StateMachineBehaviour
{
    Transform player;
    Rigidbody rb;
    public float speed;
    public float attackRange;
    public float attentionRange;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.gameObject.GetComponent<Rigidbody>();
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 target = new Vector3(player.position.x, rb.position.y, player.position.z);
        Vector3 newPos = Vector3.MoveTowards(rb.position, target, speed * Time.deltaTime);
        Vector3 forwards = target - rb.transform.position;
        rb.MovePosition(newPos);

        if (Vector3.Distance(rb.transform.position, player.transform.position) <= attackRange)
        {
            animator.SetTrigger("Attack");
        }
        if (Vector3.Distance(rb.transform.position, player.transform.position) >= attentionRange)
        {
            animator.SetTrigger("Walk");
        }

        rb.transform.forward = forwards;

    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
        animator.ResetTrigger("Walk");
    }


}
