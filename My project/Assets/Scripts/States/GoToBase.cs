using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToBase : StateMachineBehaviour
{
    private AgentBehaviours agentBehaviours;
   
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agentBehaviours = animator.GetComponent<AgentBehaviours>();

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //go to base
        agentBehaviours.GoToBase();  

        //if flag is lost trigger transition to go to flag state
        if (agentBehaviours.holdingFlag != true)
        {
            animator.SetInteger("AgentState", 0);
        }
    }

    
}
