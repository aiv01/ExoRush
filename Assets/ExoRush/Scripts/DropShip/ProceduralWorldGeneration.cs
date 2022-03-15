using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralWorldGeneration : MonoBehaviour
{
    //Vegetation
    public string TypeOfObjectName;
    public GameObject[] VegetationLibrary;
    GameObject[] VegetationPool;
    public int VegetationAmount = 100;
    int VegetationIndex;
    float VegetationCowntdown;    
    public Vector2 VegetationMinMaxDelayRange;
    public float SpawnDistance = 100;
    public float HorizontalRange = 40;

    //Dropship
    public DropShipMovement DropShipMovement;



    void Start()
    {
        VegetationPool = new GameObject[VegetationAmount+1];
        for (int i = 0; i < VegetationAmount; i++)
        {
            VegetationPool[i] = Instantiate(VegetationLibrary[Random.Range(0,VegetationLibrary.Length)], transform.position, Quaternion.Euler(0,Random.Range(0,360),0));
            VegetationPool[i].SetActive(false);
        }
    }


    void Update()
    {
        if (VegetationCowntdown <= 0)
        {
            SpawnVegetation();
            VegetationCowntdown = (Random.Range(VegetationMinMaxDelayRange.x, VegetationMinMaxDelayRange.y));            
        }

        VegetationCowntdown = VegetationCowntdown - Time.deltaTime;

        
        
    }

    public void SpawnVegetation()
    {
        RaycastHit hit;
        if(Physics.Raycast(new Vector3(Random.Range(HorizontalRange, HorizontalRange * -1), 100, transform.position.z + SpawnDistance), Vector3.down,out hit))
        {
            VegetationPool[VegetationIndex].transform.position = hit.point;

            VegetationPool[VegetationIndex].SetActive(true);
            VegetationIndex++;
            if (VegetationIndex >= VegetationAmount)
            {
                VegetationIndex = 0;
            }
        }
        
    }
}
