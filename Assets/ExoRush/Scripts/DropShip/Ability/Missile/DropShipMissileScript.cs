using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropShipMissileScript : MonoBehaviour
{

    public float ReloadTime = 4;
    float ReloadCowntDown;
    public GameObject Rocket;
    public Transform RocketShootPoint;
    [HideInInspector]
    public bool CanActivate;

    //LVL
    public LIVDefMap AbilityLoader;
    public int AbilityLvl;
    public int AbilityIndex;

    void Start()
    {
        AbilityLvlLoader();
    }


    void Update()
    {
        if (Input.GetButton("Ability")&&CanActivate)
        {
            if (ReloadCowntDown < 0)
            {
                ReloadCowntDown = ReloadTime;
                Instantiate(Rocket, RocketShootPoint.position, RocketShootPoint.rotation);
            }
        }

        ReloadCowntDown -= Time.deltaTime;    

    }

    public void AbilityLvlLoader()
    {
        AbilityLvl = AbilityLoader.AbilityLvl[AbilityIndex] + 1;
    }
}
