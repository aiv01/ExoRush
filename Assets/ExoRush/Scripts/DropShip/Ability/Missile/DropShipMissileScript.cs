using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropShipMissileScript : MonoBehaviour
{

    public float ReloadTime = 4;
    float ReloadCowntDown;
    public GameObject Rocket;
    public Transform RocketShootPoint;

    void Start()
    {

    }


    void Update()
    {
        if (Input.GetButton("Laser"))
        {
            if (ReloadCowntDown < 0)
            {
                ReloadCowntDown = ReloadTime;
                Instantiate(Rocket, RocketShootPoint.position, RocketShootPoint.rotation);
                Debug.Log("Shoot");
            }
        }

        ReloadCowntDown -= Time.deltaTime;

        



    }
}
