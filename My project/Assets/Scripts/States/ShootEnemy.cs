using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemy : StateMachineBehaviour
{
    AgentBehaviours agentBehaviours;
    float shootingTimer = 0;
    float shootingInterval = 1f;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        agentBehaviours = animator.GetComponent<AgentBehaviours>();
        
    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //shoot each target in range
        foreach (GameObject opponent in agentBehaviours.TargetsInRange())
        {
            shootingTimer += Time.deltaTime;
            if (shootingTimer >= shootingInterval)
            {
                agentBehaviours.ShootTarget(opponent);
                shootingTimer = 0f;
            }

            
        }
        //trigger transition back to follow teammate state
        animator.SetInteger("AgentState", 3);
        
    }
}
