using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LIVDefMap : LIV
{
    [SerializeField] private SaveLogic sl;
    [SerializeField] private int scoreValue;

    public override void UpdateSelected(bool currency, bool indexes = false, bool leaderboard = false, bool score = false)
    {
        int scr = sl.sObj.score;
        if (score)
        {
            scr = scoreValue;
        }
        sl.UpdateScore(scr, true);
    }
    
}
