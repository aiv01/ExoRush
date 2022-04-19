using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuGridChangeLogic : MonoBehaviour, IMenuInteractable
{
    [SerializeField] private GamepadMapper fromGrid;
    [SerializeField] private GamepadMapper toGrid;


    public void Execute()
    {
        fromGrid.LeaveItem();
        fromGrid.enabled = false;
        toGrid.enabled = true;
        toGrid.HighlightItem();
    }
}
