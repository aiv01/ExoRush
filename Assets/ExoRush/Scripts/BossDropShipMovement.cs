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

    float YRot;
    float ZRot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        YRot += Input.GetAxis("Horizontal") * Time.deltaTime * YRotationSpeed*-1;

        ZRot += Input.GetAxis("Vertical") * Time.deltaTime * ZRotationSpeed;

        //Limits
        ZRot = Mathf.Clamp(ZRot, ZMaxRotation.x, ZMaxRotation.y);

        //TargetLocation
        OriginPosition.transform.eulerAngles = new Vector3(0, YRot,ZRot);

        //ShipLocation
        transform.position = Vector3.Lerp(transform.position, TargetShipTransform.position, Time.deltaTime * ReachPositionSpeed);

        transform.rotation = Quaternion.Lerp(transform.rotation, TargetShipTransform.rotation, Time.deltaTime * ReachRotationSpeed);
    }
}
