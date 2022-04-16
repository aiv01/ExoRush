using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyeserSpawner : MonoBehaviour
{
    public GameObject Gyeser;
    public int AmountOfSpawn;
    public GameObject SpawnPoint;

    void Start()
    {
        for(int i = 0; i < AmountOfSpawn; i++)
        {
            this.transform.rotation = Quaternion.Euler(0, (360 / AmountOfSpawn) * i, 0);
            Instantiate(Gyeser, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
        }
    }


    void Update()
    {
        
    }
}
