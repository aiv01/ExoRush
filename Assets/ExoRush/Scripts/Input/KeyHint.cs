using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHint : MonoBehaviour
{
    public InputDeviceCheck DeviceScript;
    public Devices CurrentDevice;


    void OnEnable()
    {
        DeviceScript.OnInputChanged += InputChanged;
    }

    void OnDisable()
    {
        DeviceScript.OnInputChanged -= InputChanged;
    }

    private void InputChanged(Devices Device)
    {

    }


}
