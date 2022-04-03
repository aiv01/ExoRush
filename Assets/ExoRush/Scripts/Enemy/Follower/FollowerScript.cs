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
    public GameObject ViewPoint;

    public Animator FollowerAnimator;

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

        var mask = ~(22 << 24);
        mask = ~mask;

        if (Vector3.Distance (ViewPoint.transform.position, Ship.transform.position) < SpotDistance)
        {
            if (Physics.Linecast(ViewPoint.transform.position, Ship.transform.position,out hit,mask))
            {
                Debug.DrawLine(ViewPoint.transform.position, Ship.transform.position,Color.red);
                Debug.Log(hit.rigidbody.name);
                
                GoToPlayer(false);

            }
            else
            {
                Debug.DrawLine(ViewPoint.transform.position, Ship.transform.position, Color.green);
                Debug.Log("NotFound");
                GoToPlayer(true);
                RotateToPlayer();
            }
        }


      
    }

    void RotateToPlayer()
    {
        var lookPos = Ship.transform.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * RotationDamping);
    }

    void GoToPlayer(bool Follow)
    {
        FollowerAnimator.SetBool("Fleeing", Follow);
    }
}
