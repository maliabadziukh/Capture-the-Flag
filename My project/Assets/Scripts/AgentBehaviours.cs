using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentBehaviours : MonoBehaviour
{   
    GameController gameController;
    Vector3 flag;
    NavMeshAgent agent;
    public bool holdingFlag;
    //public GameObject playerBase;
    public float health = 1;
    public GameObject healthBar;
    
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

    }

  
    void Update()
    {
        //update healthbar
        healthBar.transform.localScale = new Vector3(health, 1, 1);

        if (gameController.playerWithFlag == this.gameObject)
        {
            holdingFlag = true;
            Debug.Log("holding flag");
        }
        else
        {
            holdingFlag = false;
        }
    }

    public void GoToFlag()
    {
        //goes to flag instance using navmesh
        flag = gameController.flagInstance.transform.position;
        agent.SetDestination(flag);
    }

}
