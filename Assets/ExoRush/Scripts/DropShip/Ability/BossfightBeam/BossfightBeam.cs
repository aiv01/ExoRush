using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossfightBeam : MonoBehaviour
{
    public GameObject BeamStartingPoint;
    Vector3 hitPos;
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
        }

        Debug.DrawRay(BeamStartingPoint.transform.position, BeamStartingPoint.transform.forward*9999, Color.green);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(hitPos, 1);
    }
}
