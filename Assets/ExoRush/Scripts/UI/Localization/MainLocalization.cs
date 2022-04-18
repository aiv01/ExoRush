using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Lenguage {ENG,IT,JP,ES};

public class MainLocalization : MonoBehaviour
{
    static public Lenguage CurrentLenguage;

    public delegate void InputDelegate(Lenguage type);

    public event InputDelegate OnLenguageChanged = null;

    void Start()
    {
        CurrentLenguage = Lenguage.IT;
        OnLenguageChanged(CurrentLenguage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
