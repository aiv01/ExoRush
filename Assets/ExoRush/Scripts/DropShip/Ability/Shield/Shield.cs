using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject Shiled;
    bool Active;

    // Start is called before the first frame update
    void Start()
    {
        Shiled.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Shiled.SetActive(true);
            Active = true;
        }
        else
        {
            Shiled.SetActive(false);
            Active = false;
        }
    }
}
