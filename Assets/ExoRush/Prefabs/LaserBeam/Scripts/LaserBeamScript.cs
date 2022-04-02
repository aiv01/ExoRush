using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeamScript : MonoBehaviour
{

    private LineRenderer laser;
    private ParticleSystem beam;
    // Start is called before the first frame update
    void Awake()
    {
        laser = GetComponentInChildren<LineRenderer>();
        beam = GetComponentInChildren<ParticleSystem>();
        ActivateLaser(true);
        ActivateBeam(true);
    }

    public void SetActivation(bool status)
    {
        ActivateLaser(status);
        ActivateBeam(status);
    }

    private void ActivateLaser(bool active)
    {
        laser.gameObject.SetActive(active);
    }

    private void ActivateBeam(bool active)
    {
        beam.gameObject.SetActive(active);
    }

    public void SetLaserTarget(Vector3 target)
    {
        laser.SetPosition(1, target);
    }
}
