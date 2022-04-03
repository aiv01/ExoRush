using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDropShipMovement : MonoBehaviour
{

    public Transform TargetShipTransform;
    public float ReachPositionSpeed = 1;
    public float ReachRotationSpeed = 1;
    public float YRotationSpeed = 10;
    public float ZRotationSpeed = 10;

    public Vector2 ZMaxRotation;

    public GameObject OriginPosition;

    public GameObject ShipCenter;

    float YInputForce;
    float ZInputForce;

    float YRot;
    float ZRot;

    Vector2 ZLimitReduction = new Vector2 (1,1);

    //BossDash
    public AnimationCurve DashCurve;
    public float DashAmplifier = 1;
    bool IsDashing;
    public float InverseDashDuration = 1;
    float DashTimer;
    float DashValue;
    bool RightDash;
    public AnimationCurve DashAnimationCurve;
    float DashRotation;
    bool LastInputDirectionRight;

    //AesteticVariables

    //Y Axsis
    public float YRotationAmplifier;
    float YSmoothRotation;
    public float YAnimationRotationSpeed = 1;
    //ZAxsis
    public float ZRotationAmplifier;
    float ZSmoothRotation;
    public float ZAnimationRotationSpeed = 1;
    //Engines
    public GameObject LeftEngine;
    public GameObject RightEngine;
    public float YEngineRotationAmplification;
    public float EngineRotationSpeed = 1;
    float YEngineRotation;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        YInputForce = Input.GetAxis("Horizontal");

        ZInputForce = Input.GetAxis("Vertical");

        if (YInputForce != 0)
        {
            if(YInputForce < 0)
            {
                LastInputDirectionRight = true;
            }
            else
            {
                LastInputDirectionRight = false;
            }
        }

        if (IsDashing)
        {
            Dash();
            YRot -= DashValue * Time.deltaTime;
        }
        else
        {
            if (Input.GetAxis("Jump") > 0.8f)
            {
                IsDashing = true;
                DashTimer = 0;
                if (LastInputDirectionRight)
                {
                    RightDash = true;
                }
                else
                {
                    RightDash = false;
                }
            }

            YRot -= (YInputForce * Time.deltaTime * YRotationSpeed);
        }

        //Border Reduction

        if (ZInputForce > 0)
        {

           ZLimitReduction.x = ((ZRot - ZMaxRotation.y) / 20);           

           ZLimitReduction.x = Mathf.Abs(ZLimitReduction.x);

           ZLimitReduction.x = Mathf.Clamp(ZLimitReduction.x, 0, 1);

        }
        else
        {
            ZLimitReduction.x = 1;
        }

        if (ZInputForce < 0)
        {

            ZLimitReduction.y = ((ZRot - ZMaxRotation.x) / 20*-1);

            ZLimitReduction.y = Mathf.Abs(ZLimitReduction.y);

            ZLimitReduction.y = Mathf.Clamp(ZLimitReduction.y, 0, 1);

        }
        else
        {
            ZLimitReduction.y = 1;
        }


        ZRot += ZInputForce * Time.deltaTime * ZRotationSpeed * ZLimitReduction.x * ZLimitReduction.y;

        //Limits
        ZRot = Mathf.Clamp(ZRot, ZMaxRotation.x, ZMaxRotation.y);

        //TargetLocation
        OriginPosition.transform.eulerAngles = new Vector3(0, YRot,ZRot);

        //ShipLocation

        transform.position = Vector3.Lerp(transform.position, TargetShipTransform.position, Time.deltaTime * ReachPositionSpeed);

        transform.rotation = Quaternion.Lerp(transform.rotation, TargetShipTransform.rotation, Time.deltaTime * ReachRotationSpeed);


    }

    private void LateUpdate()
    {
        //VisualAnimation
        //Ship

        YSmoothRotation = Mathf.Lerp(YSmoothRotation, YInputForce, Time.deltaTime * YAnimationRotationSpeed);

        ZSmoothRotation = Mathf.Lerp(ZSmoothRotation, ZInputForce, Time.deltaTime * ZAnimationRotationSpeed);

        ShipCenter.transform.localEulerAngles = new Vector3(ZSmoothRotation*ZRotationAmplifier*-1, 0, DashRotation+(YSmoothRotation*YRotationAmplifier*-1));
        //Engine
        YEngineRotation = Mathf.Lerp(YEngineRotation, YInputForce, Time.deltaTime * EngineRotationSpeed);

        LeftEngine.transform.localEulerAngles = new Vector3(YEngineRotation*YEngineRotationAmplification, 0, 0);
        RightEngine.transform.localEulerAngles = new Vector3(YEngineRotation * YEngineRotationAmplification * -1, 0, 0);
    }

    void Dash()
    {
        DashTimer = DashTimer + (Time.deltaTime * InverseDashDuration);

        DashValue = DashCurve.Evaluate(DashTimer);

        DashValue = DashValue * DashAmplifier;

        DashRotation = DashAnimationCurve.Evaluate(DashTimer);

        if (!RightDash)
        {
            DashRotation *= -1;
        }

        if (RightDash)
        {
            DashValue = DashValue*-1;
        }

        if (DashTimer >= 1)
        {
            IsDashing = false;
        }
    }
}
