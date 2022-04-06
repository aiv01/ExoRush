using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingMovement : MonoBehaviour
{
    public Animation RotAnim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotAnim = 
        transform.rotation = Quaternion.EulerRotation(0,0,0);
    }
}
