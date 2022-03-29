using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CurrencyLogic : MonoBehaviour
{
    public SaveLogic sl;
    public UnityEvent onCurrencyChange;
    public int currency = 0;

    private void Awake()
    {
        currency = sl.sObj.currency;
    }

    // to avoid infinite iterations, the method only works if the paramater and the currency values are different
    // calls all listeners to update their status
    public void ChangeCurrencyValue(int value)
    {
        if (currency != value)
        {
            currency = value;
            onCurrencyChange.Invoke();
        }
    }

    
}
