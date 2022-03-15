using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAbility : MonoBehaviour
{
    public GameObject[] LaserGameObject;
    public AnimationCurve LaserRotationCurve;
    public AnimationCurve LaserWidthCurve;
    float CurrentLaserWidth;
    bool IsUsingLaser;
    float NormalizedAnimation;
    public float AnimationLenght = 1;
    float CurrentRotation;
    public float ReloadTime = 2;
    float ReloadTimer;


    void Start()
    {
        for (int i = 0; i < LaserGameObject.Length; i++)
        {
            LaserGameObject[i].GetComponent<LineRenderer>().widthMultiplier = CurrentLaserWidth = 0;

        }
        ReloadTimer = ReloadTime;
    }


    void Update()
    {
        if (Input.GetButton("Laser"))
        {
            if(!IsUsingLaser)
            {
                if(ReloadTimer >= ReloadTime)
                {
                    IsUsingLaser = true;
                    NormalizedAnimation = 0;
                }


            }

        }
        if (IsUsingLaser)
        {
            NormalizedAnimation = NormalizedAnimation + (Time.deltaTime * AnimationLenght);

            CurrentRotation = LaserRotationCurve.Evaluate(NormalizedAnimation);
            CurrentLaserWidth = LaserWidthCurve.Evaluate(NormalizedAnimation);

            for (int i = 0; i < LaserGameObject.Length; i++)
            {
                LaserGameObject[i].GetComponent<LineRenderer>().widthMultiplier = CurrentLaserWidth;
                if(i == 0)
                {
                    LaserGameObject[i].transform.rotation = Quaternion.Euler(CurrentRotation, -0.8f, 0);
                }
                else
                {
                    LaserGameObject[i].transform.rotation = Quaternion.Euler(CurrentRotation, 0.8f, 0);
                }

            }
        }
        if(NormalizedAnimation > 1.5 && IsUsingLaser == true)
        {
            IsUsingLaser = false;
            ReloadTimer = 0;

            for (int i = 0; i < LaserGameObject.Length; i++)
            {
                LaserGameObject[i].GetComponent<LineRenderer>().widthMultiplier = CurrentLaserWidth = 0;

            }
        }

        if (!IsUsingLaser)
        {
            ReloadTimer = ReloadTimer + Time.deltaTime;
        }


    }
}
