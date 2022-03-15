using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollImpact : MonoBehaviour
{
    public Rigidbody RB;
    public float ImpactForce;
    public float VerticalForce = 50;
    public float LateralForce;
    Collider[] colChildren;
    DropShipMovement ShipSpeed;
    float MaxSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        if(Random.Range(0,2) != 0)
        {
            LateralForce = LateralForce * -1;
        }

        colChildren = gameObject.GetComponentsInChildren<Collider>();
        for (int i = 0; i < colChildren.Length; i++)
        {
            if (colChildren[i].gameObject != gameObject)
                colChildren[i].enabled = false;
        }

        ShipSpeed = (DropShipMovement)FindObjectOfType(typeof(DropShipMovement));

        if (ShipSpeed.CurrentVelocity >= MaxSpeed)
        {
            ImpactForce = ImpactForce * 0.2f;
        }

        RB.velocity = new Vector3(LateralForce, VerticalForce, (ImpactForce* ShipSpeed.CurrentVelocity));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
