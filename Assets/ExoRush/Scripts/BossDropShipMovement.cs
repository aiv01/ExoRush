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

    float YRot;
    float ZRot;

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




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        YInputForce = Input.GetAxis("Horizontal");

        if(YInputForce != 0)
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
            if (Input.GetKeyDown(KeyCode.Space))
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
               
        ZRot += Input.GetAxis("Vertical") * Time.deltaTime * ZRotationSpeed;

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

        YSmoothRotation = Mathf.Lerp(YSmoothRotation, YInputForce, Time.deltaTime * YAnimationRotationSpeed);

        ZSmoothRotation = Mathf.Lerp(YSmoothRotation, ZRot, Time.deltaTime * ZAnimationRotationSpeed);

        ShipCenter.transform.localEulerAngles = new Vector3(0, 0, DashRotation+(YSmoothRotation*YRotationAmplifier*-1));
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
