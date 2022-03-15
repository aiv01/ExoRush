using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementScript : MonoBehaviour
{
    public GameObject TargetLocation;
    public float CameraHeight = 15;
    float ActualCameraZPosition;
    public Camera CameraReference;
    public DropShipMovement DropShipReference;
    public float FovIncreaseMultiplier = 50;
    public GameObject CameraHolder;
    public float DefaultFov;



    //Camera shake
    // Camera Information
    public Transform cameraTransform;
    private Vector3 orignalCameraPos;
    // Shake Parameters
    public float shakeDuration = 2f;
    public float shakeAmount = 0.7f;
    private bool canShake = false;
    private float _shakeTimer;


    void LateUpdate()
    {
        ActualCameraZPosition = TargetLocation.transform.position.z;

        //UpdateFov
        CameraReference.fieldOfView = DefaultFov + (DropShipReference.CurrentVelocity * FovIncreaseMultiplier);

        //Update camera location
        CameraHolder.transform.position = new Vector3(0, CameraHeight, ActualCameraZPosition);  



    }



    //CameraShake
    void Start()
    {
        orignalCameraPos =  transform.localPosition;
    }

    void Update()
    {


        if (canShake)
        {
            StartCameraShakeEffect();
        }
    }

    public void ShakeCamera()
    {
        canShake = true;
        _shakeTimer = shakeDuration;
    }

    public void StartCameraShakeEffect()
    {
        if (_shakeTimer > 0)
        {
            transform.localPosition = orignalCameraPos + Random.insideUnitSphere * shakeAmount;
            _shakeTimer -= Time.deltaTime;
        }
        else
        {
            _shakeTimer = 0f;
            transform.localPosition = orignalCameraPos;
            canShake = false;
        }
    }
}


