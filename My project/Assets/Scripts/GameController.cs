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
    public GameObject startScreen;
    public GameObject endScreenA;
    public GameObject endScreenB;

    public GameObject playerWithFlag = null;
    public string winningTeam = null;

    void Start()
    {
        startScreen.SetActive(true);


    }


    void Update()
    {

        if (flagCaptured == true)
        {
            EndGame(); 
        }
    }

    public void StartGame()
    {
        startScreen.SetActive(false);
        endScreenA.SetActive(false);
        endScreenB.SetActive(false);
        flagInstance = Instantiate(flagPrefab, flagBase.transform.position, flagBase.transform.rotation);
        A1 = Instantiate(playerA1, baseA.transform.position, baseA.transform.rotation);
        A2 = Instantiate(playerA2, baseA.transform.position, baseA.transform.rotation);
        B1 = Instantiate(playerB1, baseB.transform.position, baseB.transform.rotation);
        B2 = Instantiate(playerB2, baseB.transform.position, baseB.transform.rotation);
    }

    void EndGame()
    {
        Destroy(A1);
        Destroy(A2);
        Destroy(B1);
        Destroy(B2);
        Destroy(flagInstance);
        if (winningTeam == "BaseA")
        {
            endScreenA.SetActive(true);
        } else if (winningTeam == "BaseB")
        {
            endScreenB.SetActive(true);
        }
        flagCaptured = false;
        
    }

}