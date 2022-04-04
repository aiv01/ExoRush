using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LIVMainMenu : LIV
{
    [SerializeField] SaveLogic sl;

    private void Awake()
    {
        sl.LoadFile();
    }

    public override void UpdateSelected(bool currency, bool indexes = false, bool leaderboard = false, bool score = false)
    {
        if (score)
        {
            int scr = 0;
            sl.UpdateScore(scr, true);
        }
        
    }
}
