using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LodMultiplier : MonoBehaviour
{
    public float multiplier = 5;

    void Start()
    {
        QualitySettings.lodBias = 5;
    }


}
