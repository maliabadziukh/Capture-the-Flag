using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int speed = 100;
    public GameObject target;
    public GameObject bulletPrefab;
    public Transform shootingPoint;
    public float shootingInterval = 2f;
    public float shootingTimer = 0f;
    List<GameObject> targets = new List<GameObject>();
    int offset = 90;

    void Start()
    {
        StartCoroutine(NewTarget());
    }

    
    void Update()
    {
        //if there are targets within range, choose a random target, turn towards it and call the shooting function if the interval has passed
         if (targets.Count > 0)
         {
            if (!targets.Contains(target))
            {
                target = targets[Random.Range(0, targets.Count)];   
            }
            
            float angle = offset + Mathf.Atan2(target.transform.position.y - transform.position.y, target.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, speed * Time.deltaTime);

            shootingTimer += Time.deltaTime;
            if (shootingTimer >= shootingInterval)
            { 
                ShootPlayer();
                shootingTimer = 0f;
            }
                
         }
        
    }

    //add a player to possible targets list when they enter the collider
    public void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag=="TeamA" || collision.gameObject.tag == "TeamB")
        {
            targets.Add(collision.gameObject);
        }
    }

    //remove a player from possible targets list when they exit the collider 
    public void OnTriggerExit2D(Collider2D collision){
        if (targets.Contains(collision.gameObject))
        {
            targets.Remove(collision.gameObject);
        }
    }

    //coroutine that runs every 2 seconds and chooses a new random target from the list
    IEnumerator NewTarget()
    {
        yield return new WaitForSeconds(2f);

        if (targets.Count >0)
        {
            target = targets[Random.Range(0, targets.Count)];
        }

        StartCoroutine(NewTarget());
    }

    void ShootPlayer(){
        //spawn bullet
        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = shootingPoint.right * bullet.GetComponent<EnemyBullet>().speed;
    }
}
