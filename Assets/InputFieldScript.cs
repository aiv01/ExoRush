using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputFieldScript : MonoBehaviour
{
    private TMP_InputField textObj;
    private TMP_Text target;

    [SerializeField] private GameObject[] affectedObjects;
    [SerializeField] private MonoBehaviour[] affectedScripts;

    private void Awake()
    {
        textObj = GetComponentInChildren<TMP_InputField>();
    }

    private void OnEnable()
    {
        textObj.enabled = false;
    }

    public void ActivateInputField()
    {
        Debug.Log("InputField activated");
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
        target.text = textObj.text;
        DeactivateInputField();
    }

    public void AssignText(TMP_Text text)
    {
        target = text;
    }
}
