using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralTerrainAutomaticMovement : MonoBehaviour
{
    public GameObject Terrain1;
    public GameObject Terrain2;
    public float TerrainSize = 4097;
    public float TerrainOffset = -400;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Terrain1.transform.position.z + TerrainSize < transform.position.z)
        {
            Terrain1.transform.position = new Vector3(TerrainSize*-0.5f,TerrainOffset,Terrain1.transform.position.z + (TerrainSize * 2));
        }

        if (Terrain2.transform.position.z + TerrainSize < transform.position.z)
        {
            Terrain2.transform.position = new Vector3(TerrainSize * -0.5f,TerrainOffset,Terrain2.transform.position.z + (TerrainSize * 2));
        }
    }
}
