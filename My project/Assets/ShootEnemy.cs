using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemy : StateMachineBehaviour
{
    AgentBehaviours agentBehaviours;
    float shootingTimer = 0;
    float shootingInterval = 2f;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Debug.Log("Shoot state active");
        agentBehaviours = animator.GetComponent<AgentBehaviours>();
        foreach (GameObject opponent in agentBehaviours.TargetsInRange())
        {
            //Debug.Log(opponent.name);
            agentBehaviours.ShootTarget(opponent);
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        shootingTimer += Time.deltaTime;
        foreach (GameObject opponent in agentBehaviours.TargetsInRange())
        {
            if (shootingTimer >= shootingInterval)
            {
                agentBehaviours.ShootTarget(opponent);
                shootingTimer = 0f;
            }
            
        }
       
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
