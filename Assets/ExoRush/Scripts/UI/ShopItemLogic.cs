using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItemLogic : MonoBehaviour
{
    [SerializeField] private int[] prices;
    [SerializeField] private TMP_Text currencyText;
    [SerializeField] private RectTransform upgradeTokensBar;
    [SerializeField] private GameObject upgradeToken;

    private TMP_Text priceText;
    private Button button;
    private GameObject[] tokens;
    
    private int price = 0;
    private int priceIndex = 0; //<--- TO BE SAVED
    private int currency = 0;   //<--- TO BE SAVED

    private void Awake()
    {
        priceText = GetComponentInChildren<TMP_Text>();
        button = GetComponentInChildren<Button>();
        upgradeTokensBar.sizeDelta = new Vector2(50 * prices.Length, upgradeTokensBar.rect.height);

        tokens = new GameObject[prices.Length];
        for (int i = 0; i < tokens.Length; i++)
        {
            tokens[i] = Instantiate(upgradeToken, upgradeTokensBar.transform);
            Vector3 newPos = new Vector3(tokens[i].transform.localPosition.x + 50 * i, tokens[i].transform.localPosition.y);
            tokens[i].transform.localPosition = newPos;
            tokens[i].GetComponent<TokenLogic>().ActiveStatus = (i <= priceIndex - 1);
            //tokens[i].transform.localPosition = new Vector3(50 * priceIndex, tokens[i].transform.position.y);
        }
    }

    //if numeric value is detected returns true and changes value 
    private bool GetTextValues(TMP_Text item, ref int value) 
    {
        return int.TryParse(item.text, out value);
    }

    private void UpdateValues()
    {
        if (!GetTextValues(currencyText, ref currency)) currency = 0;
        if (priceIndex > 0) button.GetComponentInChildren<Text>().text = "UPGRADE";

        //Debug.LogFormat("Values updated; currency: {0}, price: {1}", currency, price);
        if (price > currency)
        {
            button.interactable = false;
            priceText.color = Color.red;
        } else if (priceIndex == prices.Length)
        {
            button.GetComponentInChildren<Text>().text = "MAXED";
            button.interactable = false;
            priceText.color = Color.gray;
        }
        else 
        { 
            button.interactable = true;
            priceText.color = Color.black;
        }
    }

    //updates price to the next value in the pool
    private void UpdatePrice()
    {
        if (priceIndex < prices.Length)
        {
            price = prices[priceIndex];
        } else
        {
            price = 0;
        }
    }

    private void UpdateTokens()
    {
        for (int i = 0; i < tokens.Length; i++)
        {
            tokens[i].GetComponent<TokenLogic>().ActiveStatus = (i <= priceIndex - 1);
        }
    }

    void Start()
    {
        price = prices[priceIndex];
        UpdateValues();
    }

    public void OnButtonClicked()
    {
        if (currency >= price)
        {
            currency -= price;
            currencyText.text = currency.ToString();

            priceIndex++;
            UpdatePrice();
            priceText.text = price.ToString();
        }
        UpdateValues();
        UpdateTokens();
    }
}
