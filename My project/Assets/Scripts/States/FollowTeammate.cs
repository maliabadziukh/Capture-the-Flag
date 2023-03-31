using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTeammate : StateMachineBehaviour
{
    GameController gameController;
    AgentBehaviours agentBehaviours;
   
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        gameController = FindObjectOfType<GameController>();
        agentBehaviours = animator.GetComponent<AgentBehaviours>();
    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //follow teammate (A1)
        agentBehaviours.FollowPlayer(gameController.A1);
        //if there is a target in range, trigger state transition to shoot 
        if (agentBehaviours.TargetsInRange().Length > 0)
        {
            animator.SetInteger("AgentState", 2);
        }
    }

}
