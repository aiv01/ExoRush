using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class SaveManager
{
    public static string directory = "/SaveData/";
    public static string fileName = "DataFile.txt";

    public static void Save(SaveObject sObj)
    {
        string dir = Application.persistentDataPath + directory;

        if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

        //string json = Encrypt(JsonUtility.ToJson(sObj));
        string json = JsonUtility.ToJson(sObj);
        File.WriteAllText(dir + fileName, json);
    }

    public static SaveObject Load()
    {
        string fullPath = Application.persistentDataPath + directory + fileName;
        SaveObject sObj = new SaveObject();

        if (File.Exists(fullPath))
        {
            //string json = Decode(File.ReadAllText(fullPath));
            string json = File.ReadAllText(fullPath);
            Debug.Log(json);
            sObj = JsonUtility.FromJson<SaveObject>(json);
            Debug.LogFormat("Loaded {0}", fullPath);
        }else
        {
            Debug.Log("Could not find DataFile. New DataFile created");
            Save(sObj);
        }

        return sObj;
    }


    //WIP
    private static string Encrypt(string message)
    {
        string encryptedString = "";
        string reverseEncryptedString = "";
        int c;
        for(int i = 0; i < message.Length; i++)
        {
            c = System.Convert.ToInt32(message[i]) + 5;
            encryptedString += System.Convert.ToChar(c);
        }
        for(int i = 0; i < encryptedString.Length; i++)
        {
            reverseEncryptedString += encryptedString[encryptedString.Length - 1 - i];
        }
        return reverseEncryptedString;
    }

    private static string Decode(string reverseEncryptedString)
    {
        string encryptedString = "";
        string message = "";
        int c;
        for (int i = 0; i < reverseEncryptedString.Length; i++)
        {
            encryptedString += reverseEncryptedString[reverseEncryptedString.Length - 1 - i];
        }
        for (int i = 0; i < encryptedString.Length; i++)
        {
            c = System.Convert.ToInt32(encryptedString[i] - 5);
            message += System.Convert.ToChar(c);
        }
        return message;
    }
}
