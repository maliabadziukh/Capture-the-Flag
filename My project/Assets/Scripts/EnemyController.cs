using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int speed = 100;
    public GameObject target = null;
    public GameObject bulletPrefab;
    public Transform shootingPoint;
    public float shootingInterval = 2f;
    public float shootingTimer = 0f;
    int offset = 90;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null){
            float angle = offset + Mathf.Atan2(target.transform.position.y - transform.position.y, target.transform.position.x -transform.position.x ) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, speed * Time.deltaTime);

            shootingTimer += Time.deltaTime;
            if (shootingTimer >= shootingInterval){
                ShootPlayer();
                shootingTimer = 0f;
            }
        }
        
    }
    public void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag=="Player"){
            target = collision.gameObject;
        }
    }

    public void OnTriggerExit2D(Collider2D collision){
        if (collision.gameObject.tag == "Player"){
            target = null;
        }
    }


    void ShootPlayer(){
        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = shootingPoint.right * bullet.GetComponent<Bullet>().speed;
    }
}
