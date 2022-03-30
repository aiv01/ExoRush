using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class ShopItemLogic : MonoBehaviour, IButtonInteractable
{
    public int[] prices;
    public TMP_Text currencyText;
    [Space]
    [SerializeField] private RectTransform upgradeTokensBar;
    [SerializeField] private GameObject upgradeToken;
    [Space]
    [SerializeField] private GameObject highlighter;

    private TMP_Text priceText;
    private Button button;
    private GameObject[] tokens;
    private CurrencyLogic currLogic;
    private AudioLogic audioLogic;


    private int price = 0;
    private Color color;

    public int priceIndex = 0; //<--- TO BE SAVED
    public int currency = 0;   //<--- TO BE SAVED


    private void Awake()
    {
        currLogic = currencyText.gameObject.GetComponent<CurrencyLogic>();
        audioLogic = GetComponentInChildren<AudioLogic>();
        priceText = GetComponentInChildren<TMP_Text>();
        button = GetComponentInChildren<Button>();
        color = highlighter.GetComponent<Image>().color;
        upgradeTokensBar.sizeDelta = new Vector2(50 * prices.Length, upgradeTokensBar.rect.height);
        InstantiateTokens();
    }

    private void InstantiateTokens()
    {
        tokens = new GameObject[prices.Length];
        for (int i = 0; i < tokens.Length; i++)
        {
            tokens[i] = Instantiate(upgradeToken, upgradeTokensBar.transform);
            Vector3 newPos = new Vector3(tokens[i].transform.localPosition.x + 50 * i, tokens[i].transform.localPosition.y);
            tokens[i].transform.localPosition = newPos;
            tokens[i].GetComponent<TokenLogic>().ActiveStatus = (i <= priceIndex - 1);
        }
    }

    //if numeric value is detected returns true and changes value 
    private bool GetTextValues(TMP_Text item, ref int value) 
    {
        return int.TryParse(item.text, out value);
    }

    /* reads the values from the texts ands assignes them as numbers
     * calls the ChangeCurrencyValue() method to update all other items
     * checks if the item is still purchasable
    */
    public void UpdateValues()
    {
        if (!GetTextValues(currencyText, ref currency)) currency = 0;
        if (priceIndex > 0) button.GetComponentInChildren<Text>().text = "UPGRADE";
        currLogic.ChangeCurrencyValue(currency);

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
    public void UpdatePrice()
    {
        if (priceIndex < prices.Length)
        {
            price = prices[priceIndex];
        } else
        {
            price = 0;
        }
        priceText.text = price.ToString();
    }

    public void UpdateTokens()
    {
        for (int i = 0; i < tokens.Length; i++)
        {
            tokens[i].GetComponent<TokenLogic>().ActiveStatus = (i <= priceIndex - 1);
        }
    }

    //tied to an event system to change currency automatically
    public void OnCurrencyChange() => UpdateValues();

    public void OnButtonClicked()
    {
        if (currency >= price)
        {
            currency -= price;
            currencyText.text = currency.ToString();

            priceIndex++;
            UpdatePrice();
            audioLogic.PlayPurchaseClip();
        }
        UpdateValues();
        UpdateTokens();
    }

    public void OnItemHighlighted() => highlighter.SetActive(true);

    public void OnItemLeft() => highlighter.SetActive(false);
}
