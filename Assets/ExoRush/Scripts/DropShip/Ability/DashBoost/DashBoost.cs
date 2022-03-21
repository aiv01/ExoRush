using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashBoost : MonoBehaviour
{

    public KeyCode joystickAbilityKey = KeyCode.Joystick1Button1;
    public AnimationCurve DashBoostAnimationFlipped;
    public AnimationCurve DashBoostSpeedFlipped;
    public float DashDuration = 5;
    float DashDurationCowntdown;
    bool IsActivated;
    public DropShipMovement MovementScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(joystickAbilityKey))
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
            }

            MovementScript.BoostSpeedRotation = DashBoostAnimationFlipped.Evaluate(DashDurationCowntdown/DashDuration);

            MovementScript.BoostSpeed = DashBoostSpeedFlipped.Evaluate(DashDurationCowntdown / DashDuration);
        }


    }

    void Dash()
    {
        IsActivated = true;
        DashDurationCowntdown = DashDuration;
    }
}
