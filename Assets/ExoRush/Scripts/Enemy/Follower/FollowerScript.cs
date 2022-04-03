using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerScript : MonoBehaviour
{
    public float BottomDistance = 3;
    public float TopOffset = 0.5f;

    GameObject Ship;

    public float SpotDistance;
    public float AttackRadius = 100;
    public float DamageRadius = 80;
    bool HasDamaged;

    public float RotationDamping;
    public float FallingSpeed = 1;
    public float MovementSpeed;
    public GameObject ViewPoint;

    public Animator FollowerAnimator;

    public GameObject WalkingGround;
    public float GroundCheckDistance = 40;

    public float DestroyOffset;

    bool Attacked;

    // Start is called before the first frame update
    void Start()
    {
        Ship = Object.FindObjectOfType<DropShipMovement>().gameObject;

        StartCoroutine(CheckKill());
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

        //CheckGround

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

                if (Physics.Raycast(WalkingGround.transform.position, WalkingGround.transform.forward, out hit, GroundCheckDistance))
                {
                    GoToPlayer(true);
                }
                else
                {
                    GoToPlayer(false);
                }
                

                RotateToPlayer();
            }
        }

        if (Vector3.Distance(transform.position, Ship.transform.position) < AttackRadius)
        {
            if (!Attacked)
            {
                Attacked = true;
                FollowerAnimator.SetTrigger("Attack");
            }
            

        }


        if (Vector3.Distance(transform.position, Ship.transform.position) < DamageRadius && !HasDamaged)
        {
            Object.FindObjectOfType<InGameHealth>().Damage(300, true, false, false);
            HasDamaged = true;
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

    public void Shoot()
    {

    }

    public void CheckIfBehind()
    {
        if (transform.position.z < Ship.transform.position.z + DestroyOffset)
        {
            Destroy(this);
        }

    }

    IEnumerator CheckKill()
    {
        yield return new WaitForSeconds(1f);
        CheckIfBehind();
    }
}
