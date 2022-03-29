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
        sl.SaveFile();
        sl.LoadFile();
    }

    private void Start()
    {
        powerUps = sl.sObj.powerUpIndexes;
        items = GetComponentsInChildren<ShopItemLogic>();

        //powerUps and items should be at the same lenght. Should they not be, the limit will be set at the lowest value
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
