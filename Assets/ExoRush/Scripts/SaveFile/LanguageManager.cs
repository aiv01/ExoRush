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
            Debug.Log("Could not find Language File. New Language File created");
            Save(sLan);
        }

        return sLan;
    }
}
