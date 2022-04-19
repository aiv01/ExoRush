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
        if(LanguageText.Length <= (int)language)
        {
            TextToChange.text = LanguageText[(int)language];
        }
        else
        {
            Debug.Log("TranslationNotFound");
        }
        
    }

}
