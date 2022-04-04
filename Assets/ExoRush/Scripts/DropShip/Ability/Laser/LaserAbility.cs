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
    [HideInInspector]
    public bool CanActivate;
    public AudioSource LaserSound;

    //Damage
    public float BetweenDamageTime;
    float TempDamageTime;
    public int Damage;

    //LVL
    public LIVDefMap AbilityLoader;
    public int AbilityLvl;
    public int AbilityIndex;

    public LayerMask Layer;

    void Start()
    {
        AbilityLvlLoader();

        for (int i = 0; i < LaserGameObject.Length; i++)
        {
            LaserGameObject[i].GetComponent<LineRenderer>().widthMultiplier = CurrentLaserWidth = 0;
        }
        ReloadTimer = ReloadTime;

    }

    private void OnDisable()
    {
        IsUsingLaser = false;

    }
    void Update()
    {


        if (Input.GetButton("Ability")&&CanActivate)
        {
            if(!IsUsingLaser)
            {
                if(ReloadTimer >= ReloadTime)
                {
                    IsUsingLaser = true;
                    NormalizedAnimation = 0;
                    LaserSound.Play();
                }
            }

        }

        TempDamageTime -= Time.deltaTime;

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
                    LaserGameObject[i].transform.rotation = Quaternion.Euler(CurrentRotation, -0.8f, this.transform.rotation.eulerAngles.z);


                }
                else
                {
                    LaserGameObject[i].transform.rotation = Quaternion.Euler(CurrentRotation, 0.8f, this.transform.rotation.eulerAngles.z);


                }

                RaycastHit hit;

                if (TempDamageTime <= 0)
                {

                    if (Physics.Raycast(LaserGameObject[i].transform.position, LaserGameObject[i].transform.forward, out hit, Mathf.Infinity,Layer))
                    {
                        if (hit.collider.gameObject.GetComponent<EnemyMaster>() != null)
                        {
                            hit.collider.gameObject.GetComponent<EnemyMaster>().Damage(Damage);

                            TempDamageTime = BetweenDamageTime;
                        }
                        ////Debug.DrawRay(LaserGameObject[i].transform.position, LaserGameObject[i].transform.forward, Color.yellow);                    
                    }
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

    public void AbilityLvlLoader()
    {
        AbilityLvl = AbilityLoader.AbilityLvl[AbilityIndex] + 1;
    }
}
