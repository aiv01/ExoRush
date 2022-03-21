using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDestruction : MonoBehaviour
{
    public MeshRenderer PhysicalBox;
    public GameObject DestructibleBox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void DestroyBox()
    {
        PhysicalBox.enabled = false;
        DestructibleBox.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
