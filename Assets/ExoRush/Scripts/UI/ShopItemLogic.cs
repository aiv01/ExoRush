using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItemLogic : MonoBehaviour
{
    [SerializeField] private TMP_Text currencyText;
    private TMP_Text priceText;
    private Button button;
    private int currency = 0, price = 0;

    private void Awake()
    {
        priceText = GetComponentInChildren<TMP_Text>();
        button = GetComponentInChildren<Button>();
    }

    //if numeric value is detected returns true and changes value 
    private bool GetTextValues(TMP_Text item, int value) 
    {
        return int.TryParse(item.text, out value);
    }

    void UpdateValues()
    {
        if (!GetTextValues(currencyText, currency)) Debug.Log("could not find currency value");
        if (!GetTextValues(currencyText, currency)) currency = 0;
        if (!GetTextValues(priceText, price)) price = 1000;

        Debug.LogFormat("Values updated; currency: {0}, price: {1}", currency, price);
        if (price > currency)
        {
            button.interactable = false;
            priceText.color = Color.red;
        }
        else 
        { 
            button.interactable = true;
            priceText.color = Color.black;
        }
    }

    void Start()
    {
        UpdateValues();
    }

    public void OnButtonClicked()
    {
        if (currency >= price)
        {
            currency -= price;
            price += 10000;
            priceText.text = price.ToString();
            currencyText.text = currency.ToString();
        }
        Debug.Log("button clicked");
        UpdateValues();
    }
}
