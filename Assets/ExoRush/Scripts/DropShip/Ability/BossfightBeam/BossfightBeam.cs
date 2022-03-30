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

    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(BeamStartingPoint.transform.position, BeamStartingPoint.transform.forward, out hit, Mathf.Infinity))
        {
            hitPos = hit.point;
            if(hit.collider.tag == "BossSphere")
            {
                Damage = Mathf.Pow(StartingDamage,HittingTime);

                Debug.Log(Damage);

                Damage = Damage*Time.deltaTime * 1000;

                hit.collider.transform.root.GetComponent<EnemyMaster>().Damage((int) Damage);
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

        Debug.DrawRay(BeamStartingPoint.transform.position, BeamStartingPoint.transform.forward*9999, Color.green);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(hitPos, 1);
    }
}
