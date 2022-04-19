using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Language {ENG,IT,ES,FR,last};

public class MainLocalization : MonoBehaviour
{
    static public Language CurrentLanguage;

    public delegate void InputDelegate(Language type);

    public event InputDelegate OnLanguageChanged = null;

    void Start()
    {
        UpdateLenguage(CurrentLanguage);
    }

    public void UpdateLenguage(Language choosedlenguage)
    {
        OnLanguageChanged(choosedlenguage);
        CurrentLanguage = choosedlenguage;
    }

    public void Refresh()
    {
        UpdateLenguage(CurrentLanguage);
    }

}
