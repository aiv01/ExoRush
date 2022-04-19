using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLanguageSettings : MonoBehaviour
{
    private SaveLanguage sLan;
    private MainLocalization[] objs;

    private bool firstFrame = true;
    private bool updateLan = true;

    private void Awake()
    {
        sLan = LanguageManager.Load();
    }

    private void Update()
    {
        if (firstFrame)
        {
            firstFrame = false;
            return;
        }
        if (updateLan)
        {
            sLan = LanguageManager.Load();
            objs = gameObject.GetComponentsInChildren<MainLocalization>();
            int value = (Language) sLan.language < Language.last ? sLan.language : 0;
            sLan.language = value;
            foreach (var item in objs)
            {
                item.UpdateLenguage((Language)sLan.language);
            }
            updateLan = false;
        }
        
    }

    public void UpdateLanguage()
    {
        updateLan = true;
    }
}
