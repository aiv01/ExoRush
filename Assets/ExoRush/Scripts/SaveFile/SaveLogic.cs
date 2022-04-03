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

    public void UpdateAll(int currency, int[] indexes, int[] leaderboard, bool saveFile = false)
    {
        UpdateObjCurrency(currency);
        UpdateObjIndexes(indexes);
        UpdateObjLeaderboard(leaderboard);
        if (saveFile) SaveFile();
    }

    public void UpdateObjCurrency(int currency, bool saveFile = false)
    {
        sObj.currency = currency;
        if (saveFile) SaveFile();
    }

    public void UpdateObjIndexes(int[] indexes, bool saveFile = false)
    {
        sObj.powerUpIndexes = indexes;
        if (saveFile) SaveFile();
    }

    public void UpdateObjLeaderboard(int[] leaderboard, bool saveFile = false)
    {
        sObj.leaderboard = leaderboard;
        if (saveFile) SaveFile();
    }
}
