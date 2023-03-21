using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
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
        if (collision.gameObject.CompareTag("Player")){
            collision.gameObject.GetComponent<PlayerController>().health -= damage;
            Destroy(gameObject);
        }
        
    }    
}
