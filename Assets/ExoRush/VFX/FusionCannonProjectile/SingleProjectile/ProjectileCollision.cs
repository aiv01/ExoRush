using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    void OnParticleCollision(GameObject other)
    {
        print("Particle hit!");
        Destroy(other, 0f);
    }
}
