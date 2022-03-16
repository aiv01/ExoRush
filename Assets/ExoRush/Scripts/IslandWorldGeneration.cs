using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandWorldGeneration : MonoBehaviour
{
    public GameObject[] IslandPoolLibrary;
    GameObject[] IslandPool;
    public int IslandAmount = 20;
    int IslandIndex;
    float IslandCowntdown;
    public float SpawnDistance = 100;
    public float SpawnTimeCowntdown;
    public float HeightOffset;


    // Start is called before the first frame update
    void Start()
    {
        IslandPool = new GameObject[IslandAmount + 1];
        for (int i = 0; i < IslandAmount; i++)
        {
            IslandPool[i] = Instantiate(IslandPoolLibrary[Random.Range(0, IslandPoolLibrary.Length)], transform.position, Quaternion.Euler(0, 0, 0));
            IslandPool[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IslandCowntdown <= 0)
        {
            SpawnIsland();
            IslandCowntdown = SpawnTimeCowntdown;
        }

        IslandCowntdown = IslandCowntdown - Time.deltaTime;
    }

    public void SpawnIsland()
    {
        IslandPool[IslandIndex].transform.position = new Vector3(0, HeightOffset, transform.position.z + SpawnDistance);

        IslandPool[IslandIndex].SetActive(true);
        IslandIndex++;
        if (IslandIndex >= IslandAmount)
        {
            IslandIndex = 0;
        }
    }
}