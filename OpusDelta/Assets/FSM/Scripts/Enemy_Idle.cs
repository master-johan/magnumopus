using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Idle : StateMachineBehaviour
{

    Transform player;
    Rigidbody rb;

    Vector3 entryPos;
    Vector3[] wanderPoints;
    Vector3 wanderPos;
    Vector3 velocity;

    public float runningRange;
    public float speed;
   
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.gameObject.GetComponent<Rigidbody>();
        wanderPoints = new Vector3[4];
        wanderPos = Vector3.zero;
        velocity = Vector3.zero;

        entryPos = rb.position;

        CreatingWanderPoints();
        GetRandomWanderPos();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
     

        if (Vector3.Distance(wanderPos, rb.position) <= 1)
        {
            GetRandomWanderPos();
        }

        velocity = wanderPos.normalized * speed * Time.deltaTime;

        rb.MovePosition(Vector3.MoveTowards(rb.position, wanderPos, speed * Time.deltaTime));

        //rb.MovePosition(Vector3.SmoothDamp(rb.position, wanderPos, ref velocity, 1));
        
        rb.transform.forward = wanderPos - rb.position;

        if (Vector3.Distance(player.transform.position, rb.transform.position) <= runningRange)
        {
            animator.SetTrigger("Run");
        }
    }

    private void CreatingWanderPoints()
    {
        Vector3 offsetRight = new Vector3(entryPos.x + 5, entryPos.y, entryPos.z);
        Vector3 offsetLeft = new Vector3(entryPos.x - 5, entryPos.y, entryPos.z);
        Vector3 offsetForward = new Vector3(entryPos.x, entryPos.y, entryPos.z + 5);
        Vector3 offsetBackward = new Vector3(entryPos.x, entryPos.y, entryPos.z - 5);

        wanderPoints[0] = offsetRight;
        wanderPoints[1] = offsetLeft;
        wanderPoints[2] = offsetForward;
        wanderPoints[3] = offsetBackward;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        animator.ResetTrigger("Run");
    }

    private void GetRandomWanderPos()
    {
        wanderPos = wanderPoints[Random.Range(0, wanderPoints.Length)];
    }

}
