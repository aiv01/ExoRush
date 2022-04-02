using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandScriptLever : MonoBehaviour
{
    public GameObject FinalBlock;
    public float Speed = 1;
    bool Activated;
    float YPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Activated)
        {
            YPos -= Time.deltaTime*Speed;
            FinalBlock.transform.position = new Vector3(FinalBlock.transform.position.x, FinalBlock.transform.position.y + YPos, FinalBlock.transform.position.z);
        }
    }

    public void LeverActivated()
    {
        Activated = true;
    }
}
