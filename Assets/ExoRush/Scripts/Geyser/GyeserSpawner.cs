using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyeserSpawner : MonoBehaviour
{
    public GameObject Gyeser;
    public int AmountOfSpawn;
    public GameObject SpawnPoint;
    public GameObject SpawnRock;
    public Vector3 rockScale;

    void Start()
    {
        for(int i = 0; i < AmountOfSpawn; i++)
        {
            this.transform.rotation = Quaternion.Euler(0, (360 / AmountOfSpawn) * i, 0);
            Instantiate(Gyeser, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
            var rock = Instantiate(SpawnRock, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
            rock.transform.localScale = rockScale;
        }
    }


    void Update()
    {
        
    }
}
