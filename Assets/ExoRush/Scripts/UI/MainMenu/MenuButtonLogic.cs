using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonLogic : MonoBehaviour, IButtonInteractable
{
    [SerializeField] private GameObject highlighter;
    
    private IMenuInteractable buttonLogics;

    private void Awake()
    {
        buttonLogics = GetComponent<IMenuInteractable>();
    }

    public void OnButtonClicked()
    {
        if (buttonLogics != null) buttonLogics.Execute();
    }

    public void OnItemHighlighted()
    {
        highlighter.SetActive(true);
    }

    public void OnItemLeft()
    {
        highlighter.SetActive(false);
    }

}
