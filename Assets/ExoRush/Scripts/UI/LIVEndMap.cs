using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LIVEndMap : LIV
{
    private SaveLogic sl;
    private int[] lbValues;
    private string[] lbNames;

    private void Awake()
    {
        sl = GetComponent<SaveLogic>();
    }
}
