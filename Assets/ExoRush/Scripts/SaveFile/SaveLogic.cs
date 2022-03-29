using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLogic : MonoBehaviour
{
    [SerializeField] public SaveObject sObj;
    public void SaveFile()
    {
        SaveManager.Save(sObj);
    }

    public void LoadFile()
    {
        sObj = SaveManager.Load();
    }
}
