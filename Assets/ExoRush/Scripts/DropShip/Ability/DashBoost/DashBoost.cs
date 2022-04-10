using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashBoost : MonoBehaviour
{
    public AnimationCurve DashBoostAnimationFlipped;
    public AnimationCurve DashBoostSpeedFlipped;
    public float DashDuration = 5;
    float DashDurationCowntdown;
    bool IsActivated;
    public DropShipMovement MovementScript;
    [HideInInspector]
    public bool CanActivate;
    public InGameHealth HealthManager;

    //LVL
    public LIVDefMap AbilityLoader;
    public int AbilityLvl;
    public int AbilityIndex;



    // Start is called before the first frame update
    void Start()
    {
        AbilityLvlLoader();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Ability")&&CanActivate)
        {
            if (!IsActivated)
            {
                Dash();
            }

        }


        if (IsActivated)
        {
            DashDurationCowntdown -= Time.deltaTime;

            if(DashDurationCowntdown <= 0)
            {
                IsActivated = false;
                HealthManager.DashInvulnerability = false;
            }

            MovementScript.BoostSpeedRotation = DashBoostAnimationFlipped.Evaluate(DashDurationCowntdown/DashDuration);

            MovementScript.BoostSpeed = DashBoostSpeedFlipped.Evaluate(DashDurationCowntdown / DashDuration);
        }


    }


    public void Dash()
    {
        IsActivated = true;
        HealthManager.DashInvulnerability = true;
        DashDurationCowntdown = DashDuration;
    }

    void OnDisable()
    {
        MovementScript.BoostSpeedRotation = 0;

        MovementScript.BoostSpeed = 1;
    }

    public void AbilityLvlLoader()
    {
        AbilityLvl = AbilityLoader.AbilityLvl[AbilityIndex] + 1;
    }

}
