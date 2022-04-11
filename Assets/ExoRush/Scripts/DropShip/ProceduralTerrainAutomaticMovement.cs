using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralTerrainAutomaticMovement : MonoBehaviour
{
    public GameObject[] TerrainPool;
    public float TerrainSize = 4097;
    public float TerrainOffset = -400;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Move terrain
        for (int i = 0; i < TerrainPool.Length; i++)
        {
            if (TerrainPool[i].transform.position.z + TerrainSize < transform.position.z)
            {
                TerrainPool[i].transform.position = new Vector3(TerrainSize * -0.5f, TerrainOffset, TerrainPool[i].transform.position.z + (TerrainSize * 2));
            }
        }
    }
}
