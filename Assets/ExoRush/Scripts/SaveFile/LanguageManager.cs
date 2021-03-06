using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LanguageManager : MonoBehaviour
{
    public static string directory = "/SaveData/";
    public static string fileName = "Language.txt";

    public static void Save(SaveLanguage sLan)
    {
        string dir = Application.persistentDataPath + directory;

        if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

        string json = JsonUtility.ToJson(sLan);
        File.WriteAllText(dir + fileName, json);
    }

    public static SaveLanguage Load()
    {
        string fullPath = Application.persistentDataPath + directory + fileName;
        SaveLanguage sLan = new SaveLanguage();

        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            sLan = JsonUtility.FromJson<SaveLanguage>(json);
        }
        else
        {
            if (Application.systemLanguage == SystemLanguage.English)
            {
                sLan.language = (int)Language.ENG;
            }
            else if(Application.systemLanguage == SystemLanguage.Italian)
            {
                sLan.language = (int)Language.IT;
            }
            else if (Application.systemLanguage == SystemLanguage.Spanish)
            {
                sLan.language = (int)Language.ES;
            }
            else if (Application.systemLanguage == SystemLanguage.French)
            {
                sLan.language = (int)Language.FR;
            }
            Debug.Log("Could not find Language File. New Language File created");
            Save(sLan);
        }

        return sLan;
    }
}
