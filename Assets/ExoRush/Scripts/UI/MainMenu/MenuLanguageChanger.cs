using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLanguageChanger : MonoBehaviour, IMenuInteractable
{
    [SerializeField] private int shift;
    [SerializeField] private LoadLanguageSettings lLS;

    private SaveLanguage sLan;

    void Awake()
    {
        sLan = LanguageManager.Load();
    }

    public void Execute()
    {
        int index = sLan.language;

        if ((Language) (index + shift) >= Language.last)
        {
            sLan.language = (Language)(index + shift) - Language.last;
        }else if ((Language)index + shift < 0)
        {
           sLan.language = Language.last - (Language)(index - shift);
        } else
        {
            sLan.language = index + shift;
        }
        LanguageManager.Save(sLan);
        lLS.UpdateLanguage();
    }
}
