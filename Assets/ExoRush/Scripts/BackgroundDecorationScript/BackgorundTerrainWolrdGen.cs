using UnityEngine;

public class BackgorundTerrainWolrdGen : MonoBehaviour
{
    public int Depth = 20;

    public int Height = 256;
    public int Width = 256;

    public float scale = 20f;

    public float offsetX = 0;
    public float offsetY = 0;

    public Terrain terrain;

    public bool ForceUpdate;

    public bool Mirror;


    private void Start()
    {
        //offsetX = Random.value * 100000;
        //offsetY = Random.value * 100000;
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
        if (Mirror)
        {
            scale = scale * -1;
        }
    }

    public void Update()
    {
        if (ForceUpdate)
        {
            ForceUpdate = false;
            terrain.terrainData = GenerateTerrain(terrain.terrainData);
        }

    }

    TerrainData GenerateTerrain (TerrainData terrainData)
    {
        terrainData.heightmapResolution = Width + 1;

        terrainData.size = new Vector3 (Width, Depth, Height);

        terrainData.SetHeights(0, 0, GenerateHeights());

        return terrainData;
    }

    float[,] GenerateHeights()
    {

        float[,] heights = new float[Width, Height];
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
               heights[x, y] = CalculateHeight(x, y);
            }
                
        }

        return heights;
    }


    float CalculateHeight(int x,int y)
    {
      float xCoord = (float)x / Width * scale + offsetX;
      float yCoord = (float)y / Height * scale + offsetY;

      return Mathf.PerlinNoise(xCoord, yCoord);        
    }
}
