using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject Shiled;
    public bool Active;
    float ShieldEnergy = 1;
    public float EnergyDrainedSpeed;
    public float ReloadTime;
    public float ReuseTime;

    // Start is called before the first frame update
    void Start()
    {
        Shiled.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Shiled.SetActive(true);
            Active = true;
            ShieldEnergy -= Time.deltaTime * EnergyDrainedSpeed;
        }
        else
        {
            Shiled.SetActive(false);
            Active = false;
        }
    }
}
