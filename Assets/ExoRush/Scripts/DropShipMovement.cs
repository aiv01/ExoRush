using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DropShipMovement : MonoBehaviour
{
    //Move in X Range
    public float HorizontalMovementRange = 100;
    public float HorizontalMovementSpeed = 10;
    private float XTargetLocation;
    private float XPosition;
    float ReturnVelocity = 10f;
    public float XVelocity = 1;
    //Rotation in X Range
    public float RotSpeed = 10;
    public float RotTarget;
    public float RotAmplification = 10;
    private float CurrentRot;
    float ReturnRotation = 10f;

    //Move Forward
    public float ForwardSpeed = 10;
    float CurrentForwardPosition = 1;
    public AnimationCurve AccellerationCurve;
    public float AccellerationTimer;
    public float CurveLenghtFraction = 100;
    public float CurrentVelocity;
    float BaseVelocity;
    //Damage
    private float DamageSpeedReduction = 1;
    public AnimationCurve DamageAccellerationCurve;
    float DamageAccellerationTimer;
    public float DamageRecoverySpeed = 1;

    //Decoration Movement
    public GameObject LeftEngine;
    public GameObject RightEngine;
    public float EngineRotationAmplifier = 5;
    float EngineSpeedRotation;

    //Boost
    public float BoostSpeedRotation;
    public float BoostSpeedRotationAmplifier = 50;
    public float BoostSpeed = 1;

    //BossMap
    public float TransferDistance;
    bool InTransition;
    public float TransitionTime;
    float TempTransition;


    




    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        ShipMovement();
        
        UpdateEngineRotation();

        GoToBossmap();

    }


    void ShipMovement()
    {
        //Rotation
        RotTarget = Input.GetAxis("Horizontal") * RotAmplification * -1;
        CurrentRot = Mathf.SmoothDampAngle(transform.rotation.eulerAngles.z, RotTarget, ref ReturnRotation, RotSpeed);
        transform.rotation = Quaternion.Euler(BoostSpeedRotation * BoostSpeedRotationAmplifier, 0, CurrentRot);
        //Horizontal Movement
        XTargetLocation += Input.GetAxis("Horizontal") * Time.deltaTime * HorizontalMovementSpeed;
        XTargetLocation = Mathf.Clamp(XTargetLocation, HorizontalMovementRange * -1, HorizontalMovementRange);
        XPosition = Mathf.SmoothDamp(transform.position.x, XTargetLocation, ref ReturnVelocity, XVelocity);
        //Forward Movement
        AccellerationTimer += Time.deltaTime;


        if (DamageAccellerationTimer < 1)
        {
            DamageAccellerationTimer += Time.deltaTime * DamageRecoverySpeed;
            DamageSpeedReduction = DamageAccellerationCurve.Evaluate(DamageAccellerationTimer);

        }
        DamageSpeedReduction = Mathf.Clamp(DamageSpeedReduction, 0, 1);

        BaseVelocity = AccellerationCurve.Evaluate(AccellerationTimer / CurveLenghtFraction);

        CurrentVelocity = (BaseVelocity * DamageSpeedReduction * (BoostSpeed));

        CurrentForwardPosition += ((CurrentVelocity * ForwardSpeed * Time.deltaTime));

        //UpdateTransform
        transform.position = new Vector3(XPosition, 0, CurrentForwardPosition);
    }

    public void DamagingCollision()
    {

        DamageAccellerationTimer = 0;
    }

    void UpdateEngineRotation()
    {
        EngineSpeedRotation = Mathf.SmoothStep(0, 90, BaseVelocity*EngineRotationAmplifier);
        LeftEngine.transform.eulerAngles = new Vector3(EngineSpeedRotation, transform.eulerAngles.y, transform.eulerAngles.z);
        RightEngine.transform.eulerAngles = new Vector3(EngineSpeedRotation, transform.eulerAngles.y, transform.eulerAngles.z);

    }

    void GoToBossmap()
    {
        if (!InTransition && transform.position.z >= TransferDistance)
        {
            InTransition = true;
            TempTransition = TransitionTime;
        }
        else if (InTransition)
        {
            TempTransition -= Time.deltaTime;
        }

        if(InTransition && TempTransition <= 0)
        {
            SceneManager.LoadScene("BossMap");
        }
    }

}
