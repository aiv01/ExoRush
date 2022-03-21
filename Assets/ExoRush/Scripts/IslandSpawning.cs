using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandSpawning : MonoBehaviour
{
    Transform[] SpawingObject;
    public GameObject[] ObstaclesLibrary;
    public GameObject[] EnemyLibrary;
    float SpawnRate;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hey");

        SpawingObject = this.transform.GetComponentsInChildren<Transform>();


        for(int i = 0; i < SpawingObject.Length; i++)
        {
            //Debug.Log((transform.position.z / 10000) > (Random.Range(0, Random.value)));

            if((transform.position.z / 10000) > (Random.Range(0, Random.value)))
                {

                if (SpawingObject[i].transform.tag == "OBSP")
                {
                    Instantiate(ObstaclesLibrary[Random.Range(0, ObstaclesLibrary.Length)], SpawingObject[i].transform.position, SpawingObject[i].transform.rotation);
                }
                else if (SpawingObject[i].transform.tag == "ENSP")
                {
                    Instantiate(EnemyLibrary[Random.Range(0, EnemyLibrary.Length)], SpawingObject[i].transform.position, SpawingObject[i].transform.rotation);
                }
            }


        }






    }
}
