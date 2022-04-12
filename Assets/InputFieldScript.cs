using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputFieldScript : MonoBehaviour
{
    private TMP_InputField textObj;
    private TMP_Text target;

    [SerializeField] private GameObject inputSubmenu;
    [SerializeField] private GameObject[] affectedObjects;
    [SerializeField] private MonoBehaviour[] affectedScripts;

    public void ActivateInputField()
    {
        inputSubmenu.SetActive(true);
        textObj = GetComponentInChildren<TMP_InputField>();
        textObj.Select();
        Debug.Log("InputField activated");
        textObj.enabled = true;
        foreach(var obj in affectedObjects)
        {
            obj.SetActive(false);
        }
    }

    public void DeactivateInputField()
    {
        inputSubmenu.SetActive(false);
        foreach (var scr in affectedScripts)
        {
            scr.enabled = false;
        }
    }

    public void OnEdit()
    {
        textObj.text = textObj.text;
    }

    public void OnEndEdit()
    {
        target.text = textObj.text;
        DeactivateInputField();
    }

    public void AssignText(TMP_Text text)
    {
        target = text;
    }
}
