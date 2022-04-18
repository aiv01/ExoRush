using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputFieldScript : MonoBehaviour
{
    private TMP_InputField textObj;
    private TMP_Text target;
    private bool endEdit = false;
    public LIVDefMap liv;
    public LoadScoreboard lSB;

    [SerializeField] private GameObject inputSubmenu;
    [SerializeField] private GameObject[] affectedObjects;
    [SerializeField] private MonoBehaviour[] affectedScripts;
    

    public void ActivateInputField()
    {
        inputSubmenu.SetActive(true);
        textObj = GetComponentInChildren<TMP_InputField>();
        textObj.Select();
        textObj.enabled = true;
        foreach(var obj in affectedObjects)
        {
            obj.SetActive(false);
        }
        foreach (var scr in affectedScripts)
        {
            scr.enabled = false;
        }
    }

    public void DeactivateInputField()
    {
        foreach (var obj in affectedObjects)
        {
            obj.SetActive(true);
        }
        foreach (var scr in affectedScripts)
        {
            scr.enabled = true;
        }
        inputSubmenu.SetActive(false);
    }

    private void Update()
    {
        if (endEdit)
        {
            if (Input.GetKeyUp(KeyCode.Return))
            {
                DeactivateInputField();
            }
        }
    }

    public void OnEdit()
    {
        textObj.text = textObj.text;
    }

    public void OnEndEdit()
    {
        if (target != null)
        {
            target.text = textObj.text;
        }
        lSB.UpdateLB();
        liv.UpdateSelected(false, false, true, false);
        endEdit = true;
    }

    public void AssignText(TMP_Text text)
    {
        target = text;
    }
}
