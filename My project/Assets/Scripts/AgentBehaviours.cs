using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AgentBehaviours : MonoBehaviour
{   
    GameController gameController;
    Vector3 flag;
    NavMeshAgent agent;
    public bool holdingFlag;
    public float health = 1;
    public GameObject healthBar;
    public Vector3 basePos;
    GameObject spaceshipTransform;
    public GameObject bulletPrefab;
    
    void Start()
    {
        //gets the starting position of the agent and sets it as base position
        basePos = gameObject.transform.position;

        gameController = FindObjectOfType<GameController>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        spaceshipTransform = transform.Find("Spaceship").gameObject;
    }

  
    void Update()
    {
        //rotate in movement direction
        Vector3 velocity = agent.velocity;
        if (velocity.magnitude > 0.1f)
        {
            Vector3 direction = agent.velocity.normalized;
            spaceshipTransform.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f);
        }
        //update healthbar
        healthBar.transform.localScale = new Vector3(health, 1, 1);

        if (gameController.playerWithFlag == this.gameObject)
        {
            holdingFlag = true;
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

    public void GoToBase()
    {
        //goes to base using navmesh
        agent.SetDestination(basePos);
    }

    public void FollowPlayer(GameObject player)
    {
        if (Vector3.Distance(transform.position,  player.transform.position) > 5)
        {
            agent.SetDestination(player.transform.position);
        }
       
    }

    public float DistanceToTarget(GameObject target)
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);
        return distance;
    }

    public void ShootTarget()
    {

        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = transform.right * 20f;
    }


}
