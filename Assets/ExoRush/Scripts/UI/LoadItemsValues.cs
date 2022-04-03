using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadItemsValues : LIV
{
    [SerializeField] SaveLogic sl;
    private int[] powerUps;
    private ShopItemLogic[] items;

    private void Awake()
    {
        sl.LoadFile();
    }

    public override void UpdateSelected(bool currency, bool indexes = false, bool leaderboard = false, bool score)
    {
        int curr = sl.sObj.currency;
        int scr = sl.sObj.score;
        int[] ind = sl.sObj.powerUpIndexes;
        int[] lb = sl.sObj.leaderboard;
        string[] lbnames = sl.sObj.lbNames;
        if (currency)
        { 
           curr = items[0].currency;
        }
        if (indexes)
        {
            int limit = powerUps.Length < items.Length ? powerUps.Length : items.Length;
            for (int i = 0; i < limit; i++)
            {
                ind[i] = items[i].priceIndex;
            }
        }
        sl.UpdateAll(curr, ind, lb, lbnames, scr, true);
    }

    private void Start()
    {
        powerUps = sl.sObj.powerUpIndexes;
        items = GetComponentsInChildren<ShopItemLogic>();

        //powerUps and items should always be at the same length. Should they not be, the limit will be set at the lowest value
        int limit = powerUps.Length < items.Length ? powerUps.Length : items.Length;
        for (int i = 0; i < limit; i++)
        {
            items[i].priceIndex = sl.sObj.powerUpIndexes[i];
            items[i].currencyText.text = sl.sObj.currency.ToString();
            items[i].UpdateTokens();
            items[i].UpdatePrice();
            items[i].UpdateValues();
        }

    }
}
