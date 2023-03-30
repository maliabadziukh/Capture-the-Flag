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
    float respawnDelay = 5f;
    
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

        if (health <= 0)
        {
            gameObject.SetActive(false);
            Invoke("Respawn", respawnDelay);
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

    public GameObject[] TargetsInRange()
    {
        List<GameObject> targets = new List<GameObject>();

        if (this.gameObject.CompareTag("TeamA"))
        {
            foreach (GameObject opponent in GameObject.FindGameObjectsWithTag("TeamB"))
            {
                if (Vector3.Distance(transform.position, opponent.transform.position) < 10)
                {
                    //Debug.Log("found opponent" + opponent.name);
                    targets.Add(opponent);
                }
            }
        }
        else if (this.gameObject.CompareTag("TeamB"))
        {
            foreach (GameObject opponent in GameObject.FindGameObjectsWithTag("TeamA"))
            {
                if (Vector3.Distance(transform.position, opponent.transform.position) < 10)
                {
                    //Debug.Log("found opponent" + opponent.name);
                    targets.Add(opponent);
                }
                

            }
        }
        return targets.ToArray();
    }

    public void ShootTarget(GameObject target)
    {

        //Transform spaceship = transform.Find("Spaceship");
        //Vector3 direction = target.transform.position - spaceship.position;
        //direction.z = 0f; 
        //spaceship.rotation = Quaternion.LookRotation(Vector3.forward, direction);

        //GameObject bullet = Instantiate(bulletPrefab, spaceship.position, spaceship.rotation);
        //bullet.transform.rotation *= Quaternion.Euler(0f, 0f, 90f);
        //bullet.GetComponent<Rigidbody2D>().velocity = spaceship.right * 2f;


         
        Transform spaceship = transform.Find("Spaceship");

        // Calculate direction to target
        Vector3 direction = target.transform.position - spaceship.position;
        direction.z = 0f;

        // Apply 90 degree offset
        //Vector3 bulletDirection = Quaternion.AngleAxis(-90, Vector3.forward) * direction;

        // Rotate spaceship to face the target
        spaceship.rotation = Quaternion.LookRotation(Vector3.forward, direction);

        // Spawn bullet and apply rotation and velocity
        GameObject bullet = Instantiate(bulletPrefab, spaceship.position, spaceship.rotation);
        bullet.transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
        bullet.GetComponent<Rigidbody2D>().velocity = direction.normalized * 5f;
    }

    void Respawn()
    {
        
        transform.position = basePos;
        health = 1;
        gameObject.SetActive(true);
    }

}
