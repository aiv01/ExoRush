using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadItemsValues : MonoBehaviour
{
    [SerializeField] SaveLogic sl;
    private int[] powerUps;
    private ShopItemLogic[] items;

    private void Awake()
    {
        sl.LoadFile();
    }

    public void UpdateSelected(bool currency, bool indexes = false, bool leaderboard = false)
    {
        int curr = sl.sObj.currency;
        int[] ind = sl.sObj.powerUpIndexes;
        int[] lb = sl.sObj.leaderboard;
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
        if (leaderboard)
        {
            //TBD
        }
        sl.UpdateAll(curr, ind, lb, true);
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
