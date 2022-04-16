using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldParticlesLogic : MonoBehaviour
{
    [SerializeField] private DropShipMovement dropshipRef;
    [SerializeField] private float speedOffset;

    private ParticleSystem pxSys;
    public float speed;

    private void Awake()
    {
        pxSys = gameObject.GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        var main = pxSys.main;
        speed = dropshipRef.CurrentVelocity * dropshipRef.ForwardSpeed + speedOffset;
        //main.startSpeed = speed;
        var velocity = pxSys.velocityOverLifetime;
        velocity.z = speed;
    }
}
