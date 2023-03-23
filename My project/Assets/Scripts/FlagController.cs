using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagController : MonoBehaviour
{
    GameController gameController;    
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

   
    void Update()
    {
        
    }
     public void OnTriggerEnter2D(Collider2D collision){
     if (collision.gameObject.name =="BaseA" || collision.gameObject.name =="BaseB"){
            gameController.winningTeam = collision.gameObject.tag;
            gameController.flagCaptured = true;
            
        }
   }
}
