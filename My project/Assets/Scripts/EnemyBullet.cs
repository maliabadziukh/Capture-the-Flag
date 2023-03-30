using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 2f;
    public float damage = 10;
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "TeamA" || collision.gameObject.tag == "TeamB")
        {
            collision.gameObject.GetComponent<AgentBehaviours>().health -= damage;
            Destroy(gameObject);
        }
        if (collision.gameObject.tag != "Enemy")
        {
            Destroy(gameObject);
        }


    }

    
}
