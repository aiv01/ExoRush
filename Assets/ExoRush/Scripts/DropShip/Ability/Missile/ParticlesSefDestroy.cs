using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesSefDestroy : MonoBehaviour
{
    public float Timer = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
