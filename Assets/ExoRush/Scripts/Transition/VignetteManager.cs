using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
[RequireComponent(typeof(Volume))]

public class VignetteManager : MonoBehaviour
{
    private Volume myVolume;
    private bool collisionDetected = false;
    private Vignette myVignette = null;
    [SerializeField] private float startIntesity = 0f;
    [SerializeField] private float targetIntensity = 0.7f;
    [SerializeField] private float transitionTime = 0.3f;

    private void Awake()
    {
        myVolume = GetComponent<Volume>();
        if (myVolume.profile.TryGet(out Vignette vignette))
            myVignette = vignette;
    }
    private void Start()
    {
        myVignette.intensity.Override(startIntesity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") collisionDetected = true;
    }

    private void Update()
    {
        if (collisionDetected)
        {
            myVignette.intensity.Override(myVignette.intensity.value + (transitionTime / targetIntensity) * Time.deltaTime);
            if (myVignette.intensity.value > targetIntensity)
            {
                myVignette.intensity.Override(targetIntensity);
                collisionDetected = false;
            }
        }
    }
}
