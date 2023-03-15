using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    void Start()
    {
        Instantiate(objectToSpawn, transform.position, objectToSpawn.transform.rotation);
    }
}
