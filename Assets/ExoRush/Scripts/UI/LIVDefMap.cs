using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LIVDefMap : LIV
{
    [SerializeField] private SaveLogic sl;
    [SerializeField] private Text scoreValue;       

    public int[] AbilityLvl;

    private void Awake()
    {
        sl.LoadFile();
        AbilityLvl = sl.sObj.powerUpIndexes;
        scoreValue.text = sl.sObj.score.ToString();
    }

    public override void UpdateSelected(bool currency, bool indexes = false, bool leaderboard = false, bool score = false)
    {
        int scr = sl.sObj.score;
        if (score)
        {
            scr = int.Parse(scoreValue.text);
        }
        sl.UpdateScore(scr, true);
    }
    
}
