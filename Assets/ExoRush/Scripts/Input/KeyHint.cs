using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyHint : MonoBehaviour
{
    public InputDeviceCheck DeviceScript;
    public Devices CurrentDevice;
    public Sprite[] InputSprite;
    public Image DisplayImage;


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
        Debug.Log(Device);
        DisplayImage.sprite = InputSprite[(int)Device];
    }


}
