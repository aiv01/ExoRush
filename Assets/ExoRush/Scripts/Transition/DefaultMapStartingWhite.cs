using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class DefaultMapStartingWhite : MonoBehaviour
{
    public Volume Volume;
    public float TransitionSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        Volume.weight = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Volume.weight -= Time.deltaTime * TransitionSpeed;
        if(Volume.weight < 0)
        {
            Destroy(gameObject);
        }
    }
}
