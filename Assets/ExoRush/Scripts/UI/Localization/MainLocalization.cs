using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Lenguage {ENG,IT,ES,JP};

public class MainLocalization : MonoBehaviour
{
    static public Lenguage CurrentLenguage;
    public int LenguageInt;

    public delegate void InputDelegate(Lenguage type);

    public event InputDelegate OnLenguageChanged = null;

    void Start()
    {
        UpdateLenguage(Lenguage.ES);
    }

    public void UpdateLenguage(Lenguage choosedlenguage)
    {
        OnLenguageChanged(choosedlenguage);
        CurrentLenguage = choosedlenguage;
        LenguageInt = (int)CurrentLenguage;
    }

}
