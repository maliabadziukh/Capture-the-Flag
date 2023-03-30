using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagController : MonoBehaviour
{
    GameController gameController;
    Vector3 flagPos;
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

   
    void Update()
    {
        if (gameController.playerWithFlag != null)
        {
            flagPos = new Vector3(gameController.playerWithFlag.transform.position.x, gameController.playerWithFlag.transform.position.y, -2);
            gameObject.transform.position = flagPos;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TeamA" || collision.gameObject.tag == "TeamB")
        {
            gameController.playerWithFlag = collision.gameObject;
        }
        else if (collision.gameObject.name == "BaseA" || collision.gameObject.name == "BaseB")
        {
            gameController.winningTeam = collision.gameObject.name;
            gameController.flagCaptured = true;
        }
    }
}
