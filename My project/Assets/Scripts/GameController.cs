using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject flagPrefab;
    public GameObject flagBase;
    public GameObject playerA1;
    public GameObject playerA2;
    public GameObject playerB1;
    public GameObject playerB2;
    public GameObject baseA;
    public GameObject baseB;
    public GameObject flagInstance;
    public bool flagHeld = false;
    public bool flagCaptured = false;

    public GameObject playerWithFlag = null;
    public string winningTeam = null;

    void Start()
    {
        flagInstance = Instantiate(flagPrefab, flagBase.transform.position, flagBase.transform.rotation);
        SpawnObject(playerA1, baseA);
        SpawnObject(playerA2, baseA);
        SpawnObject(playerB1, baseB);
        SpawnObject(playerB2, baseB);

    }

    
    void Update()
    {
        
        if (flagCaptured ==true){
            Debug.Log(winningTeam + " wins!");
        }
    }
    


    void SpawnObject(GameObject gameObject, GameObject position){
        Instantiate(gameObject, position.transform.position, position.transform.rotation);
    }
}
