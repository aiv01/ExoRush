using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadScoreboard : MonoBehaviour
{
    [SerializeField] private SaveLogic sl;
    [SerializeField] private GameObject[] lbTiles;
    private int[] lbValues = new int[10];
    private string[] lbNames = new string[10];
    private int score;

    // Start is called before the first frame update
    void Awake()
    {
        score = sl.sObj.score;
        lbValues = sl.sObj.leaderboard;
        lbNames = sl.sObj.lbNames;
        SortLB();
        sl.UpdateObjLeaderboard(lbValues, lbNames, true);
        SetLB();
    }

    private void SetLB()
    {
        for (int i = 0; i < lbTiles.Length; i++)
        {
            TMP_Text[] values = new TMP_Text[2];
            values = lbTiles[i].GetComponentsInChildren<TMP_Text>();
            foreach (var value in values)
            {
                if (value.gameObject.tag == "lbValue") value.text = lbValues[i].ToString();
                if (value.gameObject.tag == "lbName") value.text = lbNames[i];
            }
        }
    }

    private void SortLB()
    {
        //create temporary array and assign it with lbValues
        int[] tempValues = new int[11];
        string[] tempNames = new string[11];
        int tempValue;
        string tempName;
        for (int i = 0; i < tempValues.Length - 1; i++)
        {
            tempValues[i] = lbValues[i];
            tempNames[i] = lbNames[i];
        }
        tempValues[10] = sl.sObj.score;
        tempNames[10] = "Name";
        //sort tempArray
        for (int i = 0; i < tempValues.Length; i++)
        {
            for (int j = 0; j < tempValues.Length - i - 1; j++)
            {
                if (tempValues[j] > tempValues[j + 1])
                {
                    tempValue = tempValues[j + 1];
                    tempValues[j + 1] = tempValues[j];
                    tempValues[j] = tempValue;
                    tempName = tempNames[j + 1];
                    tempNames[j + 1] = tempNames[j];
                    tempNames[j] = tempName;
                }
            }
        }
        //Array.Sort(tempValues);
        //assign tempArray to lbValues. discard last item
        for (int i = 0; i < lbValues.Length; i++)
        {
            lbValues[i] = tempValues[lbValues.Length - i];
            lbNames[i] = tempNames[lbNames.Length - i];
        }
    }
}
