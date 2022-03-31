using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundNoise : MonoBehaviour
{
    public AudioClip[] Noise;
    public AudioSource AudioSource;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!AudioSource.isPlaying)
        {
            AudioSource.clip = Noise[Random.Range(0,Noise.Length-1)];
            AudioSource.Play();
        }
    }
}
