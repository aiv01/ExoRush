using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityLoader : MonoBehaviour
{
    public SaveObject saveObject;

    public int[] AbilityLvl;


    private void Awake()
    {
        saveObject = SaveManager.Load();
        AbilityLvl = saveObject.powerUpIndexes;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
