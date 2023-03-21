using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
   Rigidbody2D body;
   GameController gameController;
   float horizontal;
   float vertical;
   public float runSpeed = 20.0f;
   public float health = 1;
    public GameObject healthBar;

    void Start (){
      body = GetComponent<Rigidbody2D>();
      gameController = FindObjectOfType<GameController>();

   }

   void Update (){
      horizontal = Input.GetAxisRaw("Horizontal");
      vertical = Input.GetAxisRaw("Vertical");
      healthBar.transform.localScale = new Vector3(health, 1, 1);
   }

   private void FixedUpdate(){  
      body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
   }

   public void OnTriggerEnter2D(Collider2D collision){
      
      if(collision.gameObject.tag=="Flag" && gameController.flagHeld == false){
         gameController.flagHeld = true;
         gameController.playerWithFlag = this.gameObject;
      } 
      
   }
}

