using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCameraMovement : MonoBehaviour
{
    public Transform TargetLocation;
    public float ReachPositionSpeed = 1;
    public float ReachRotationSpeed = 1;
    public GameObject CameraHolder;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        CameraHolder.transform.position = Vector3.Lerp(CameraHolder.transform.position, TargetLocation.position, Time.deltaTime * ReachPositionSpeed);

        CameraHolder.transform.rotation = Quaternion.Lerp(CameraHolder.transform.rotation, TargetLocation.rotation, Time.deltaTime * ReachRotationSpeed);
    }
}
