using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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
    public GameObject A1;
    public GameObject A2;
    public GameObject B1;
    public GameObject B2;
    public bool flagHeld = false;
    public bool flagCaptured = false;

    public GameObject playerWithFlag = null;
    public string winningTeam = null;

    void Start()
    {
        flagInstance = Instantiate(flagPrefab, flagBase.transform.position, flagBase.transform.rotation);
        A1 = Instantiate(playerA1, baseA.transform.position, baseA.transform.rotation);
        A2 = Instantiate(playerA2, baseA.transform.position, baseA.transform.rotation);
        B1 = Instantiate(playerB1, baseB.transform.position, baseB.transform.rotation);
        B2 = Instantiate(playerB2, baseB.transform.position, baseB.transform.rotation);

    }

    
    void Update()
    {
        
        if (flagCaptured ==true){
            Debug.Log(winningTeam + " wins!");
        }
    }
    
}
