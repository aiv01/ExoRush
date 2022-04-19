using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextLocalization : MonoBehaviour
{
    public MainLocalization MainLocalizationScript;
    public TextMeshProUGUI TextToChange;
    public string[] LanguageText;

    void OnEnable()
    {
        MainLocalizationScript.OnLanguageChanged += LanguageChanged;
    }

    void OnDisable()
    {
        MainLocalizationScript.OnLanguageChanged -= LanguageChanged;
    }

    private void LanguageChanged(Language language)
    {
        TextToChange.text = LanguageText[(int)language];

        if ((int)language <= LanguageText.Length)
        {
            
        }
        else
        {
            Debug.Log("TranslationNotFound");
        }
        
    }

}
