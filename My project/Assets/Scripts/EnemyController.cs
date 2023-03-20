using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int speed;
    public GameObject target = null;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShootPlayer(target);
    }
    public void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag=="TeamA" || collision.gameObject.tag=="TeamB"){
            Debug.Log("Attack");
            target = collision.gameObject;
        }
    }

    public void OnTriggerExit2D(Collider2D collision){
        if (collision.gameObject.tag == "TeamA" || collision.gameObject.tag == "TeamB"){
            target = null;
        }
    }


    void ShootPlayer(GameObject target){
        float angle = Mathf.Atan2(target.transform.position.y - transform.position.y, target.transform.position.x -transform.position.x ) * Mathf.Rad2Deg;
        Debug.Log(angle);
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        Debug.Log(targetRotation);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, speed * Time.deltaTime);
    }
}
