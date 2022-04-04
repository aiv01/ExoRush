using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    private LineRenderer lr;

    public LayerMask Layer;
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        lr.SetPosition(0, transform.position);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit,Layer))
        {
            if (hit.collider)
            {
                lr.SetPosition(1, hit.point);
            }
        }
        else lr.SetPosition(1, transform.forward * 10000);
    }
}
