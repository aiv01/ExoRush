using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadScore : MonoBehaviour
{
    [SerializeField] private SaveLogic sl;
    [SerializeField] private TMP_Text currency;
    // Start is called before the first frame update
    void Awake()
    {
        gameObject.GetComponent<TMP_Text>().text = sl.sObj.score.ToString();
        sl.UpdateObjCurrency(sl.sObj.score + sl.sObj.currency, true);
        currency.text = sl.sObj.currency.ToString();
    }
}
