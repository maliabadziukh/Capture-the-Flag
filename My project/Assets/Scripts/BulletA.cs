using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletA : MonoBehaviour
{
   
    public float lifetime = 2f;
    public float damage = 0.2f;
    void Start()
    {
        //destroy bullet after lifetime has passed 
        Destroy(gameObject, lifetime);
    }


    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //destroys the bullet on collision with an object and does damage if it's an opponent 
        if (collision.gameObject.tag == "TeamB")
        {
            Debug.Log("team b collision");
            collision.gameObject.GetComponent<AgentBehaviours>().health -= damage;
            Destroy(gameObject);
        }
        if (collision.gameObject.tag != "TeamA" && collision.gameObject.tag != "Enemy")
        {
            Debug.Log("a different collision");
            Debug.Log(collision.gameObject.name);
            Destroy(gameObject);
        }


    }
}
