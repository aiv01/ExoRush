using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerScript : MonoBehaviour
{
    public float BottomDistance = 3;
    public float TopOffset = 0.5f;

    GameObject Ship;

    public float SpotDistance;

    public float RotationDamping;
    public float FallingSpeed = 1;
    public float MovementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Ship = Object.FindObjectOfType<DropShipMovement>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //StayOnGround
        RaycastHit hit;
        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + (TopOffset), transform.position.z), transform.TransformDirection(Vector3.down), out hit, BottomDistance))
        {
            transform.position = hit.point;
        }
        else
        {
            transform.position = new Vector3(transform.position.x,transform.position.y * ((Time.deltaTime * FallingSpeed)*-1));
        }

        if(Vector3.Distance (transform.position, Ship.transform.position) < SpotDistance)
        {
            if (Physics.Linecast(transform.position, Ship.transform.position))
            {
                Debug.Log("Found");
                
            }
            else
            {
                Debug.Log("NotFound");
            }
        }

        RotateToPlayer();
        GoToPlayer();
        

    }

    void RotateToPlayer()
    {
        var lookPos = Ship.transform.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * RotationDamping);

    }

    void GoToPlayer()
    {
        transform.position += Vector3.forward * Time.deltaTime * MovementSpeed;
    }
}
