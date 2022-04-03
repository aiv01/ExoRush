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

    public void UpdateAll(int currency, int[] indexes, int[] leaderboard, string[] lbNames, int score, bool saveFile = false)
    {
        UpdateObjCurrency(currency);
        UpdateObjIndexes(indexes);
        UpdateObjLeaderboard(leaderboard, lbNames);
        UpdateScore(score);
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

    public void UpdateObjLeaderboard(int[] leaderboardvalues, string[] leaderboardNames, bool saveFile = false)
    {
        sObj.leaderboard = leaderboardvalues;
        sObj.lbNames = leaderboardNames;
        if (saveFile) SaveFile();
    }

    public void UpdateScore(int score, bool saveFile = false)
    {
        sObj.score = score;
        if (saveFile) SaveFile();
    }
}
