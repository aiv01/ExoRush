using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossfightBeam : MonoBehaviour
{
    public GameObject BeamStartingPoint;
    Vector3 hitPos;
    float HittingTime;
    float Damage;
    public float StartingDamage = 1;
    public float ExponentialDamageAmplifier = 1;

    //Overcharge
    public float OverchargeSpeedAmplifier = 0.1f;
    float Overcharge;
    public float DischargeTime = 2;
    float DischageTimer;
    float DischageSpeed = 0.3f;

    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Ability")&&Overcharge < 1){

            Overcharge += Time.deltaTime * OverchargeSpeedAmplifier;

            Overcharge = Mathf.Clamp(Overcharge, 0, 1);

            Debug.Log(Overcharge);

            DischageTimer = DischargeTime;

            RaycastHit hit;
            if (Physics.Raycast(BeamStartingPoint.transform.position, BeamStartingPoint.transform.forward, out hit, Mathf.Infinity))
            {
                hitPos = hit.point;
                if (hit.collider.tag == "BossSphere")
                {
                    Damage = Mathf.Pow(StartingDamage, HittingTime);

                    Damage = Damage * Time.deltaTime * 1000;

                    hit.collider.transform.root.GetComponent<EnemyMaster>().Damage((int)Damage);
                    HittingTime += Time.deltaTime * ExponentialDamageAmplifier;
                }
                else
                {
                    HittingTime = 0;
                }


            }
            else
            {
                HittingTime = 0;
            }

            Debug.DrawRay(BeamStartingPoint.transform.position, BeamStartingPoint.transform.forward * 9999, Color.green);
        }
        else
        {
            DischageTimer -= Time.deltaTime * DischageSpeed;
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(hitPos, 1);
    }
}
