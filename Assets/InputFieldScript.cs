using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputFieldScript : MonoBehaviour
{
    private TMP_InputField textObj;
    private string text;

    [SerializeField] private GameObject[] affectedObjects;
    [SerializeField] private MonoBehaviour[] affectedScripts;

    private void OnEnable()
    {
        textObj.enabled = false;
    }

    public void ActivateInputField()
    {
        textObj.enabled = true;
        foreach(var obj in affectedObjects)
        {
            obj.SetActive(false);
        }
    }

    public void DeactivateInputField()
    {
        textObj.enabled = false;
        foreach (var scr in affectedScripts)
        {
            scr.enabled = false;
        }
    }

    public void OnEndEdit()
    {
        text = textObj.text;
        DeactivateInputField();
    }
}
