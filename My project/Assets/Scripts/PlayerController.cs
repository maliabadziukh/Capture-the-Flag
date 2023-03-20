using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
   Rigidbody2D body;
   GameController gameController;
   float horizontal;
   float vertical;
   public float runSpeed = 20.0f;
   void Start (){
      body = GetComponent<Rigidbody2D>();
      gameController = FindObjectOfType<GameController>();

   }

   void Update (){
      
      horizontal = Input.GetAxisRaw("Horizontal");
      vertical = Input.GetAxisRaw("Vertical"); 
   }

   private void FixedUpdate(){  
      body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
   }

   public void OnTriggerEnter2D(Collider2D collision){
      Debug.Log("Collided with something");
      if(collision.gameObject.tag=="Flag" && gameController.flagHeld == false){
            Debug.Log("Collided with flag");
            gameController.flagHeld = true;
            gameController.playerWithFlag = this.gameObject;
            Debug.Log(gameController.playerWithFlag.transform.position);
        }
   }
}

