using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletA : MonoBehaviour
{
   
    public float lifetime = 2f;
    public float damage = 0.2f;
    void Start()
    {
        Destroy(gameObject, lifetime);
    }


    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TeamB")
        {
            collision.gameObject.GetComponent<AgentBehaviours>().health -= damage;
            Destroy(gameObject);
        }
        if (collision.gameObject.tag != "TeamA")
        {
            Destroy(gameObject);
        }


    }
}
