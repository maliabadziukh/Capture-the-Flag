using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentBehaviours : MonoBehaviour
{   
    GameController gameController;
    Vector3 flag;
     NavMeshAgent agent;
    
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        agent = GetComponentInChildren<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

  
    void Update()
    {
        
    }

    public void GoToFlag()
    {
        Debug.Log("Go to flag func called");
        flag = gameController.flagInstance.transform.position;
        agent.SetDestination(flag);
    }
}
