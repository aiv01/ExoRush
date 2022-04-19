using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextLocalization : MonoBehaviour
{
    public MainLocalization MainLocalizationScript;
    public TextMeshProUGUI TextToChange;
    public string[] LanguageText;
    public bool RequestLanguageRefresh;

    void OnEnable()
    {
        MainLocalizationScript.OnLanguageChanged += LanguageChanged;
    }

    void OnDisable()
    {
        MainLocalizationScript.OnLanguageChanged -= LanguageChanged;
    }

    public void Start()
    {
        if (RequestLanguageRefresh)
        {
            MainLocalizationScript.Refresh();
        }
        
    }

    private void LanguageChanged(Language language)
    {        

        if ((int)language <= LanguageText.Length-1)
        {
            TextToChange.text = LanguageText[(int)language];
        }
        else
        {
            //Debug.Log("TranslationNotFound");
        }
        
    }

}
