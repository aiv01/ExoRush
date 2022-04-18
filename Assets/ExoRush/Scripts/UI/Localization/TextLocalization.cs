using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextLocalization : MonoBehaviour
{
    public MainLocalization MainLocalizationScript;
    public TextMeshProUGUI TextToChange;
    public string[] LenguageText;

    void OnEnable()
    {
        MainLocalizationScript.OnLenguageChanged += LenguageChanged;
    }

    void OnDisable()
    {
        MainLocalizationScript.OnLenguageChanged -= LenguageChanged;
    }

    private void LenguageChanged(Lenguage lenguage)
    {
        TextToChange.text = LenguageText[(int)lenguage];
    }

}
