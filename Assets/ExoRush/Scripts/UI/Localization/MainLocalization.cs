using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Language {ENG,IT,ES,JP};

public class MainLocalization : MonoBehaviour
{
    static public Language CurrentLanguage;

    public delegate void InputDelegate(Language type);

    public event InputDelegate OnLanguageChanged = null;

    void Start()
    {
        UpdateLenguage(Language.ES);
    }

    public void UpdateLenguage(Language choosedlenguage)
    {
        OnLanguageChanged(choosedlenguage);
        CurrentLanguage = choosedlenguage;
    }

}
