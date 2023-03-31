using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GoToFlag : StateMachineBehaviour
{
    private AgentBehaviours agentBehaviours;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agentBehaviours = animator.GetComponent<AgentBehaviours>();

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //go to flag 
        agentBehaviours.GoToFlag();
        //if you got the flag, trigger transition to go to base state
        if (agentBehaviours.holdingFlag == true)
        {
            animator.SetInteger("AgentState", 1);
        }
    }

   
}
