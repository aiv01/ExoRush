using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LIVEndMap : LIV
{
    private SaveLogic sl;
    private int[] lbValues = new int[10];
    private string[] lbNames = new string[10];

    [SerializeField] private GameObject[] lbTiles;

    private void Awake()
    {
        sl = GetComponent<SaveLogic>();
        sl.LoadFile();
        lbValues = sl.sObj.leaderboard;
        lbNames = sl.sObj.lbNames;
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

    public override void UpdateSelected(bool currency, bool indexes = false, bool leaderboard = false, bool score = false)
    {
        int curr = sl.sObj.currency;
        int scr = sl.sObj.score;
        int[] lb = sl.sObj.leaderboard;
        string[] lbnames = sl.sObj.lbNames;
        if (currency)
        {
            curr += scr;
        }
        if (leaderboard)
        {
            lb = lbValues;
            lbnames = lbNames;
        }
        if (score)
        {
            sl.UpdateScore(0);
        }
        sl.UpdateObjLeaderboard(lb, lbnames);
        sl.UpdateObjCurrency(curr, true);
    }
}
